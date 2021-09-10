using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/ram/metrics")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private ILogger<RamMetricsController> _logger;
        public RamMetricsController(Logger<RamMetricsController> logger)
        {
            _logger = logger;
        }
        //за период времени
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"RamMetricsController GetMetricsFromAgent agentId {agentId}, fromTime {fromTime}, toTime {toTime}");
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        //за всё время
        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromCluster()
        {
            return Ok();
        }
    }
}
