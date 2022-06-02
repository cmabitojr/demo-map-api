using demo_map_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demo_map_api.Model;
using Microsoft.EntityFrameworkCore;

namespace demo_map_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ApplicantsController (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut("{applicantID}")]
        public async Task<IActionResult> PutApplicants(string applicantid, Applicant applicant)
        {
            //  if (id != productList.id)
            //  {
            //      return BadRequest();
            //  }
            applicant.applicantID = applicantid;
            _dataContext.Entry(applicant).State = EntityState.Modified;
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!applicantListExists(applicantid))
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

        private bool applicantListExists(string id)
        {
            return _dataContext.Applications.Any(e => e.applicantID == id);
        }

        [HttpGet("{applicantID}")]
        public async Task<ActionResult<Applicant>> GetByApplicantID(string applicantID)
        {
            var applicant = await _dataContext.Applicants.FindAsync(applicantID);
            {
                return NotFound();
            }
            return applicant;
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicant(Applicant applicant)
        {
            _dataContext.Applicants.Add(applicant);
            await _dataContext.SaveChangesAsync();
            //return CreatedAtAction("GetByApplicantID", new { id = applicant.applicantID }, applicant);
            return applicant;
        }
    }
}
