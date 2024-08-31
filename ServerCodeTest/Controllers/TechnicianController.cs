using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerCodeTest.Data;
using ServerCodeTest.Models;

namespace ServerCodeTest.Controllers
{
    [Route("api/Technician")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechnicianController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Technician
        /// <summary>
        /// Gets all technicians
        /// </summary>
        /// <returns>_dbo_technicians Array</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<_dbo_technicians>>> Gettechnicians()
        {
            return await _context.technicians.ToListAsync();
        }
    }
}
