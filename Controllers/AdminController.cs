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

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            ViewBag.TotalDonors = _context.Users.Count(u => u.Role == "Donor");
            ViewBag.TotalPatients = _context.Users.Count(u => u.Role == "Patient");

            var bloodStats = _context.Donors
                .Include(d => d.BloodGroup)
                .GroupBy(d => d.BloodGroup.Name)
                .Select(g => new { BloodGroup = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            ViewBag.BloodStats = bloodStats;
            ViewBag.TotalDonorsForPercentage = ViewBag.TotalDonors > 0 ? ViewBag.TotalDonors : 1;

            return View();
        }

        // Manage Donors - List
        public IActionResult ManageDonors()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var donors = _context.Donors
                .Include(d => d.User)
                .Include(d => d.BloodGroup)
                .Select(d => new DonorViewModel
                {
                    Id = d.Id,
                    Name = d.User.Name,
                    Email = d.User.Email,
                    Phone = d.User.Phone,
                    BloodGroupName = d.BloodGroup.Name,
                    Address = d.Address,
                    WhatsApp = d.WhatsApp,
                    Facebook = d.Facebook,
                    LastDonationDate = d.LastDonationDate
                })
                .ToList();

            return View(donors);
        }

        // Delete Donor - Confirmation
        public IActionResult DeleteDonor(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var donor = _context.Donors
                .Include(d => d.User)
                .Include(d => d.BloodGroup)
                .FirstOrDefault(d => d.Id == id);

            if (donor == null) return NotFound();

            var model = new DonorViewModel
            {
                Id = donor.Id,
                Name = donor.User.Name,
                Email = donor.User.Email,
                Phone = donor.User.Phone,
                BloodGroupName = donor.BloodGroup.Name
            };

            return View(model);
        }

        // Delete Donor - Confirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDonorConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var donor = _context.Donors.Include(d => d.User).FirstOrDefault(d => d.Id == id);
            if (donor != null)
            {
                _context.Users.Remove(donor.User);
                _context.Donors.Remove(donor);
                _context.SaveChanges();
                TempData["Success"] = "Donor deleted successfully!";
            }

            return RedirectToAction("ManageDonors");
        }

        // Manage Patients - List
        // Manage Patients - List
public IActionResult ManagePatients()
{
    if (HttpContext.Session.GetString("Role") != "Admin")
        return RedirectToAction("Login", "Account");

    var patients = _context.Users
        .Where(u => u.Role == "Patient")
        .Select(u => new PatientViewModel
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Phone = u.Phone
        })
        .ToList();

    return View(patients);
}

        // Delete Patient - Confirmation
        public IActionResult DeletePatient(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var patient = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Patient");
            if (patient == null) return NotFound();

            return View(patient);
        }

        // Delete Patient - Confirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePatientConfirmed(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Account");

            var patient = _context.Users.FirstOrDefault(u => u.Id == id && u.Role == "Patient");
            if (patient != null)
            {
                _context.Users.Remove(patient);
                _context.SaveChanges();
                TempData["Success"] = "Patient deleted successfully!";
            }

            return RedirectToAction("ManagePatients");
        }
    }
}