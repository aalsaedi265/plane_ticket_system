

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data;
using System.Threading.Tasks;
using System;


namespace PlaneTicketSystem.Booking
{
[ApiController]
//Checks input data against model's validation attributes
// Verifies data types match model requirements
// Ensures required fields are present
// Validates data annotations like [Required], [StringLength], [Range]
// Automatically returns 400 Bad Request if validation fails

[Route("[controller]")] // Automatically generates route based on controller name

public class BookingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    // retrieve all bookings
    public async Task<IActionResult> GetBookings()
    { 
        return Ok(await _context.Bookings.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingRequest request)
    {
            if (request == null)
                return BadRequest("Booking data is required");

            try
            {
                // Check if flight exists and has available seats
                var flight = await _context.Schedules
                    .FirstOrDefaultAsync(s => s.FlightNumber == request.FlightNumber);

                if (flight == null)
                    return NotFound("Flight not found");

                if (flight.AvailableSeats <= 0)
                    return BadRequest("No seats available for this flight");

                // Create new booking
                var booking = new PlaneTicketSystem.Data.Models.Booking
                {
                    PassengerName = request.PassengerName,
                    FlightNumber = request.FlightNumber,
                    BookingDate = DateTime.UtcNow,
                    Status = "Confirmed",
                    Price = flight.BasePrice
                };

                // Update available seats
                flight.AvailableSeats--;

                // Save booking and update flight
                _context.Bookings.Add(booking);
                var saveResult = await _context.SaveChangesAsync();
                Console.WriteLine($"SaveChanges result: {saveResult}");
                
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
    //define the request structure
    public class BookingRequest
    {
        public required string PassengerName { get; set; }
        public required string FlightNumber { get; set; }
    }
}