using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Domain;
using Messenger.Persistence.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<Chat> _repository;

        public AuthController(IRepository<Chat> repository)
        {
            _repository = repository;
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.CountAsync());
        }
    }
}