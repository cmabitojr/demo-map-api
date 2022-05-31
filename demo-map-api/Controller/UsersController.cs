using demo_map_api.Data;
using demo_map_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo_map_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //GET: api/User
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        //GET: api/User/Username
        [HttpGet("{Username}")]
        public async Task<ActionResult<User>> GetByUsername(string Username)
        {
            var userName = await _dataContext.Users.FindAsync(Username);
            if (userName == null)
            {
                return NotFound();
            }
            return userName;
        }
    }
}