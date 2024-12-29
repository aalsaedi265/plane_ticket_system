

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data;
using System.Threading.Tasks;

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
 }}