﻿using demo_map_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
