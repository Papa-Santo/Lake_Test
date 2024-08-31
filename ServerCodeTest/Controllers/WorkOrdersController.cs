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
    [Route("api/WorkOrders")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Path has no parameters
        /// </summary>
        /// <returns>List of work orders</returns>
        // GET: api/WorkOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<_dbo_workorders>>> GetWorkorders()
        {
            return await _context.workorders.ToListAsync();
        }

        /// <summary>
        /// Path returns work order list based on status
        /// </summary>
        /// <returns>List of work orders</returns>
        [HttpGet()]
        [Route("Status")]
        public async Task<ActionResult<IEnumerable<_dbo_workorders>>> Get_Open(string status)
        {
            var _dbo_workorders = await _context.workorders.Where(wo => wo.status == status).ToListAsync();

            if (_dbo_workorders == null)
            {
                return NotFound();
            }

            return _dbo_workorders;
        }

        /// <summary>
        /// Path Creates a new work order with fields Email, ContactName, ContactNumber, Problem, Technician
        /// </summary>
        /// <returns>List of work orders</returns>
        // POST: api/WorkOrders
        [HttpPost]
        public async Task<ActionResult<_dbo_workorders>> Post_dbo_workorders(CreateWorkOrder CreateWorkOrder)
        {
            _dbo_workorders WorkOrder = new _dbo_workorders
            {
                contactname = CreateWorkOrder.contactname,
                contactnumber = CreateWorkOrder.contactnumber,
                email = CreateWorkOrder.email,
                problem = CreateWorkOrder.problem,
                technicianid = CreateWorkOrder.technicianid
            };

            _context.workorders.Add(WorkOrder);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post_dbo_workorders", new { id = WorkOrder.wonum }, WorkOrder);
        }
    }
}
