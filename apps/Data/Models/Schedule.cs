
using System;
namespace PlaneTicketSystem.Data.Models 
{
    public class Schedule
    {
        public int Id { get; set; }
        public required string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public int AvailableSeats { get; set; }
        public decimal BasePrice { get; set; }
        public required string Status { get; set; }
    }
}