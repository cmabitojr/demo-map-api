using demo_map_api.Data;
using demo_map_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_map_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ApplicationsController (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //GET: api/Application
        [HttpGet]
        public async Task<IEnumerable<Application>> GetApplications()
        {
            return await _dataContext.Applications.ToListAsync();
        }

        //GET: api/Users/Application
        [HttpGet("{applicationID}")]
        public async Task<ActionResult<Application>> GetByApplications(string applicationID)
        {
            var Application = await _dataContext.Applications.FindAsync(applicationID);
            {
                return NotFound();
            }
            return Application;
        }

        // PUT: api/Application/ID
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{applicationID}")]
        public async Task<IActionResult> PutApplications(string applicationid, Application application)
        {
            //  if (id != productList.id)
            //  {
            //      return BadRequest();
            //  }
            application.applicationID = applicationid;
            _dataContext.Entry(application).State = EntityState.Modified;
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!applicationListExists(applicationid))
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
        // POST: api/Application
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplications(Application application)
        {
            _dataContext.Applications.Add(application);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction("GetApplications", new { id = application.applicantID }, application);
        }
        private bool applicationListExists(string id)
        {
            return _dataContext.Applications.Any(e => e.applicationID == id);
        }
    }
}
