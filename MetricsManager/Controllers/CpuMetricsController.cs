using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/cpu/metrics")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        //за период времени
        //URL is: localhost:port/api/cpu/metrics/agent/1/from/DD.HH:MM:SS/to/DD.HH:MM:SS
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok($"GetMetricsFromAgent method, agentId: {agentId}, fromTime: {fromTime}, toTime: {toTime}"); //возврат значений для отладки
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
