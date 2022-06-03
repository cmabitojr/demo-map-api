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
        public async Task<IEnumerable<ApplicationList>> GetApplications()
        {
            //return await _dataContext.Applications.ToListAsync();
            //var result = await _dataContext.Applications.ToListAsync();
            //var result2 = await _dataContext.Applicants.ToListAsync();

    
            var myApplication = from a in _dataContext.Applications
                                join b in _dataContext.Applicants on a.applicantID equals b.applicantID into AB
                                from CD in AB.DefaultIfEmpty()
                                orderby a.applicationDate
                                select new { a.applicationID, a.applicationDate };
            return (IEnumerable<ApplicationList>)await myApplication.ToListAsync();
        }

        //GET: api/Users/Application
        [HttpGet("{ApplicationID}")]
        public async Task<ActionResult<Application>> GetByApplications(string applicantID)
        {
            var Application = await _dataContext.Applications.FindAsync(applicantID);
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

        public class ApplicationList
        {
            public string? applicantID { get; set; }

            public string? firstName { get; set; }

            public string? middleName { get; set; }

            public string? lastName { get; set; }

            public string? extensionName { get; set; }

            public DateTime birthday { get; set; }

            public string? applicationID { get; set; }

            public DateTime applicationDate { get; set; }

            public string assistance { get; set; }

            public string status { get; set; }
        }
    }
}
