using System;
using System.ComponentModel.DataAnnotations;

namespace CSproject.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [Required]
        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; } = null!;

        [Required]
        public string Address { get; set; } = string.Empty;

        public DateTime? LastDonationDate { get; set; }

        public bool AvailabilityStatus { get; set; } = true;
        public bool IsApproved { get; set; } = true;

        // Social contacts - nullable
        public string? WhatsApp { get; set; }  // Now nullable
        public string? Facebook { get; set; }  // Now nullable
    }
}