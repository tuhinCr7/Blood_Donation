using System;

namespace CSproject.Models
{
    public class SearchLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BloodGroupId { get; set; }
        public DateTime SearchDate { get; set; } = DateTime.Now;
    }
}