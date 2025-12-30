using Microsoft.AspNetCore.Mvc;
using CSproject.Models;
using System.Security.Cryptography;
using System.Text;

namespace CSproject.Controllers
{
    public class AccountController : Controller
    {
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            using (var context = new BloodDonationContext())
            {
                string hash = HashPassword(password);
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Role", user.Role);
                    HttpContext.Session.SetString("Name", user.Name);

                    if (user.Role == "Admin") return RedirectToAction("Dashboard", "Admin");
                    if (user.Role == "Donor") return RedirectToAction("Profile", "Donor");
                    if (user.Role == "Patient") return RedirectToAction("Search", "Patient");
                }
                ViewBag.Error = "Invalid username or password";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DonorRegister()
        {
            using (var context = new BloodDonationContext())
            {
                ViewBag.BloodGroups = context.BloodGroups.ToList();
            }
            return View();
        }

        [HttpPost]
        public IActionResult DonorRegister(User user, Donor donor, string password)
        {
            using (var context = new BloodDonationContext())
            {
                if (context.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    ViewBag.Error = "Username or Email already exists";
                    ViewBag.BloodGroups = context.BloodGroups.ToList();
                    return View();
                }

                user.PasswordHash = HashPassword(password);
                user.Role = "Donor";
                context.Users.Add(user);
                context.SaveChanges();

                donor.UserId = user.Id;
                donor.IsApproved = true;
                donor.AvailabilityStatus = true;
                context.Donors.Add(donor);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }

        public IActionResult PatientRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientRegister(User user, string password)
        {
            using (var context = new BloodDonationContext())
            {
                if (context.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    ViewBag.Error = "Username or Email already exists";
                    return View();
                }

                user.PasswordHash = HashPassword(password);
                user.Role = "Patient";
                context.Users.Add(user);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }
    }
}