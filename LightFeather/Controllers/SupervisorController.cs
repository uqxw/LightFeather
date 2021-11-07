using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LightFeather.Models;
using System.Net.Http.Json;
using System.Net.Http;


namespace LightFeather.Controllers
{
    [Route("api/supervisors")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly SupervisorContext _context;

        public SupervisorController(SupervisorContext context)
        {
            _context = context;
        }

        // GET: api/Supervisor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSupervisors()
        {
            HttpClient Http = new HttpClient();
            Supervisor[] supervisors = await Http.GetFromJsonAsync<Supervisor[]>("https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers");
            var outputs = new List<string>();

            foreach (Supervisor supervisor in supervisors)
            {
                outputs.Add(supervisor.jurisdiction + " - " + supervisor.firstName + " " + supervisor.lastName);
            }
            return outputs;
            //return await _context.Supervisors.ToListAsync();
        }

        // GET: api/Supervisor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supervisor>> GetSupervisor(long id)
        {
            var supervisor = await _context.Supervisors.FindAsync(id);

            if (supervisor == null)
            {
                return NotFound();
            }

            return supervisor;
        }

        // PUT: api/Supervisor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupervisor(long id, Supervisor supervisor)
        {
            if (id != supervisor.id)
            {
                return BadRequest();
            }

            _context.Entry(supervisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Supervisor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supervisor>> PostSupervisor(Supervisor supervisor)
        {
            _context.Supervisors.Add(supervisor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupervisor", new { id = supervisor.id }, supervisor);
        }

        // DELETE: api/Supervisor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupervisor(long id)
        {
            var supervisor = await _context.Supervisors.FindAsync(id);
            if (supervisor == null)
            {
                return NotFound();
            }

            _context.Supervisors.Remove(supervisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupervisorExists(long id)
        {
            return _context.Supervisors.Any(e => e.id == id);
        }
    }

    [Route("api/submit")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        // POST: api/Submit
        [HttpPost]
        public async Task<ActionResult<Submit>> PostSubmit(Submit submit)
        {
            if (submit.firstName == null || submit.firstName=="" ) {
                throw new ArgumentNullException(nameof(submit.firstName));
            };

            if (submit.lastName == null || submit.lastName == "")
            {
                throw new ArgumentNullException(nameof(submit.lastName));
            };
            if (submit.supervisor == null || submit.supervisor == "")
            {
                throw new ArgumentNullException(nameof(submit.supervisor));
            };

            return submit;
        }

    }


}
