
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PlaneTicketSystem.Data.Models;

namespace PlaneTicketSystem.Schedules
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            return Ok(await _context.Schedules.ToListAsync());
        }
        
        [HttpPost("seed")]
        public async Task<IActionResult> SeedSchedules()
        {
            // First, let's check if we already have data to avoid duplicates
            if (await _context.Schedules.AnyAsync())
            {
                return Ok("Database already contains flight schedules.");
            }

            // Create a list of test flight schedules
            var testFlights = new List<Schedule>
            {
                new Schedule
                {
                    FlightNumber = "AA101",
                    DepartureTime = DateTime.Now.AddDays(1).AddHours(8),
                    ArrivalTime = DateTime.Now.AddDays(1).AddHours(11),
                    Origin = "New York (JFK)",
                    Destination = "Los Angeles (LAX)",
                    AvailableSeats = 150,
                    BasePrice = 299.99m,
                    Status = "Scheduled"
                },
                new Schedule
                {
                    FlightNumber = "AA102",
                    DepartureTime = DateTime.Now.AddDays(1).AddHours(10),
                    ArrivalTime = DateTime.Now.AddDays(1).AddHours(12),
                    Origin = "Chicago (ORD)",
                    Destination = "Miami (MIA)",
                    AvailableSeats = 120,
                    BasePrice = 199.99m,
                    Status = "Scheduled"
                },
                new Schedule
                {
                    FlightNumber = "AA103",
                    DepartureTime = DateTime.Now.AddDays(2).AddHours(9),
                    ArrivalTime = DateTime.Now.AddDays(2).AddHours(13),
                    Origin = "San Francisco (SFO)",
                    Destination = "Seattle (SEA)",
                    AvailableSeats = 180,
                    BasePrice = 249.99m,
                    Status = "Scheduled"
                }
            };

            // Add the test flights to the database
            await _context.Schedules.AddRangeAsync(testFlights);
            await _context.SaveChangesAsync();

            return Ok($"Successfully added {testFlights.Count} test flights to the database.");
        }
    }
}