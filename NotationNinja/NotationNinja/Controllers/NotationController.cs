using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotationNinja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotationController : ControllerBase
    {
        private readonly ILogger<NotationController> _logger;

        public NotationController(ILogger<NotationController> logger)
        {
            _logger = logger;
        }
    }
}
