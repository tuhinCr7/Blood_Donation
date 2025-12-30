using Microsoft.AspNetCore.Mvc;
using CSproject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSproject.Controllers
{
    public class DonorController : Controller
    {
        private readonly BloodDonationContext _context;

        public DonorController(BloodDonationContext context)
        {
            _context = context;
        }

        // GET: Profile
        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("Role") != "Donor")
                return RedirectToAction("Login", "Account");

            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var donor = _context.Donors
                .Include(d => d.User)
                .Include(d => d.BloodGroup)
                .FirstOrDefault(d => d.UserId == userId);

            if (donor == null)
                return NotFound("Donor profile not found.");

            return View(donor);
        }

        // GET: Update
        public IActionResult Update()
        {
            if (HttpContext.Session.GetString("Role") != "Donor")
                return RedirectToAction("Login", "Account");

            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var donor = _context.Donors
                .Include(d => d.User)
                .Include(d => d.BloodGroup)
                .FirstOrDefault(d => d.UserId == userId);

            if (donor == null)
                return NotFound("Donor profile not found.");

            ViewBag.BloodGroups = _context.BloodGroups.ToList();
            return View(donor);
        }

        // POST: Update - FULLY FIXED
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Donor updatedDonor)
        {
            if (HttpContext.Session.GetString("Role") != "Donor")
                return RedirectToAction("Login", "Account");

            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var donor = _context.Donors
                .Include(d => d.User)
                .FirstOrDefault(d => d.UserId == userId);

            if (donor == null || donor.Id != id)
                return NotFound("Donor not found.");

            // Update user info
            donor.User.Name = updatedDonor.User.Name;
            donor.User.Email = updatedDonor.User.Email;
            donor.User.Phone = updatedDonor.User.Phone;

            // Update donor info
            donor.Address = updatedDonor.Address;
            donor.BloodGroupId = updatedDonor.BloodGroupId;
            donor.LastDonationDate = updatedDonor.LastDonationDate;
            donor.AvailabilityStatus = updatedDonor.AvailabilityStatus;

            try
            {
                _context.SaveChanges();
                TempData["Success"] = "Profile updated successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error updating profile: " + ex.Message;
            }

            return RedirectToAction("Profile");
        }
    }
}