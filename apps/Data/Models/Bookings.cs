

namespace PlaneTicketSystem.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public required string PassengerName { get; set; }
        public required string FlightNumber { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public required string Status { get; set; }
    }
}