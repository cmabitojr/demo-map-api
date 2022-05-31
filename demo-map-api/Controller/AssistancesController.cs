using demo_map_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using demo_map_api.Model;
using Microsoft.EntityFrameworkCore;

namespace demo_map_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistancesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AssistancesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //GET: api/Assistance
        [HttpGet]
        public async Task<IEnumerable<Assistance>> GetApplications()
        {
            return await _dataContext.Assistances.ToListAsync();
        }



    }
}
