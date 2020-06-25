using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotationNinja.MediatR.Requests;

namespace NotationNinja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotationController : ControllerBase
    {
        private readonly ILogger<NotationController> _logger;
        private readonly IMediator _mediator;

        public NotationController(ILogger<NotationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("ToPostfix")]
        public async Task<string> ToPostfix(string input)
        {
            return await _mediator.Send(new GetPostfix { Input = input });
        }
    }
}
