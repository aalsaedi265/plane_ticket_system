
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data;
using System.Threading.Tasks;

namespace PlaneTicketSystem.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
    }
}