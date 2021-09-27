using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/dotnet/metrics")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private ILogger<DotNetMetricsController> _logger;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Получает статистику DotNet за всё время использования
        /// </summary>
        /// <remarks>
        /// Пример:
        /// GET api/cpu/metrics/agent/5
        /// </remarks>
        /// 
        /// <returns>
        /// Получает статискику DotNet за всё время работы агента
        /// </returns>
        /// <param name="agentId">ID агента</param>
        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        //за период времени
        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"DotNetMetricsController GetMetricsFromAgent agentId {agentId}, fromTime {fromTime}, toTime {toTime}");
        //    return Ok();
        //}

        //[HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    return Ok();
        //}
        //[HttpGet("cluster")]
        //public IActionResult GetMetricsFromCluster()
        //{
        //    return Ok();
        //}
    }
}
