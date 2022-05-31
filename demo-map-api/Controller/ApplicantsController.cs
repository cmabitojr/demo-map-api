using demo_map_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
