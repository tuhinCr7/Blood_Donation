using Microsoft.AspNetCore.Mvc;
using CSproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSproject.Controllers
{
    public class AdminController : Controller
    {
        private readonly BloodDonationContext _context;

        public AdminController(BloodDonationContext context)
        {
            _context = context;
        }

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            // Role check - only admin can access
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            // Total Donors
            ViewBag.TotalDonors = _context.Users.Count(u => u.Role == "Donor");

            // Total Patients
            ViewBag.TotalPatients = _context.Users.Count(u => u.Role == "Patient");

            // Blood Group Statistics
            var bloodStats = _context.Donors
                .Include(d => d.BloodGroup)
                .GroupBy(d => d.BloodGroup.Name)
                .Select(g => new
                {
                    BloodGroup = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            ViewBag.BloodStats = bloodStats;
            ViewBag.TotalDonorsForPercentage = ViewBag.TotalDonors > 0 ? ViewBag.TotalDonors : 1;

            return View();
        }
    }
}