
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaneTicketSystem.Data;
using System.Threading.Tasks;

namespace PlaneTicketSystem.Admin
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            return Ok(await _context.Admins.ToListAsync());
        }
    }
}