namespace CSproject.Models;
public class DonorViewModel
{
    public int Id { get; set; }  // NEW - for delete
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public DateTime? LastDonationDate { get; set; }
    public string? WhatsApp { get; set; } = "";
    public string? Facebook { get; set; } = "";
    public string BloodGroupName { get; set; } = "";
    public bool AvailabilityStatus { get; set; }
}