using Microsoft.AspNetCore.Mvc;
using CSproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSproject.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Search()
        {
            if (HttpContext.Session.GetString("Role") != "Patient")
                return RedirectToAction("Login", "Account");

            using (var context = new BloodDonationContext())
            {
                ViewBag.BloodGroups = context.BloodGroups.ToList();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Search(int bloodGroupId)
        {
            if (HttpContext.Session.GetString("Role") != "Patient")
                return RedirectToAction("Login", "Account");

            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            List<DonorViewModel> eligibleDonors;

            using (var context = new BloodDonationContext())
            {
                context.SearchLogs.Add(new SearchLog
                {
                    UserId = userId,
                    BloodGroupId = bloodGroupId
                });
                context.SaveChanges();

                var fourMonthsAgo = DateTime.Now.AddMonths(-4);

                eligibleDonors = context.Donors
    .Include(d => d.User)
    .Include(d => d.BloodGroup)
    .Where(d => d.BloodGroupId == bloodGroupId &&
                d.IsApproved &&
                d.AvailabilityStatus &&
                (d.LastDonationDate == null || d.LastDonationDate < fourMonthsAgo))
    .Select(d => new DonorViewModel
    {
        Name = d.User.Name,
        Phone = d.User.Phone,
        Email = d.User.Email,
        Address = d.Address,
        LastDonationDate = d.LastDonationDate,
        WhatsApp = d.WhatsApp,  // NEW
        Facebook = d.Facebook,  // NEW
        BloodGroupName = d.BloodGroup.Name  // NEW for display
    })
    .OrderBy(d => d.LastDonationDate ?? DateTime.MinValue)
    .ToList();
            }

            return View("Results", eligibleDonors);
        }
    }
}