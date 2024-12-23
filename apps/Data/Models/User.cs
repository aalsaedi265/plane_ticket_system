
using System;
namespace PlaneTicketSystem.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
    }
}