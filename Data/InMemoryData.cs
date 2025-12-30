using CSproject.Models;

namespace CSproject.Data
{
    public static class InMemoryData
    {
        public static List<BloodGroup> BloodGroups = new()
        {
            new BloodGroup { Id = 1, Name = "A+" },
            new BloodGroup { Id = 2, Name = "A-" },
            new BloodGroup { Id = 3, Name = "B+" },
            new BloodGroup { Id = 4, Name = "B-" },
            new BloodGroup { Id = 5, Name = "AB+" },
            new BloodGroup { Id = 6, Name = "AB-" },
            new BloodGroup { Id = 7, Name = "O+" },
            new BloodGroup { Id = 8, Name = "O-" }
        };

   public static List<User> Users = new()
{
    new User 
    { 
        Id = 1, 
        Username = "admin", 
        PasswordHash = "JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=",  // Exact hash for "admin123"
        Role = "Admin", 
        Name = "Administrator", 
        Email = "admin@csproject.com", 
        Phone = "9999999999" 
    }
};

        public static List<Donor> Donors = new();
        public static List<SearchLog> SearchLogs = new();
    }
}