using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/network/metrics")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private ILogger<NetworkMetricsController> _logger;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Получает метрики сетевого трафика за всё время использования
        /// </summary>
        /// <remarks>
        /// Пример:
        /// GET api/network/metrics/agent/5
        /// </remarks>
        /// 
        /// <returns>
        /// Получает метрики сетевого трафика за всё время работы агента
        /// </returns>
        /// <param name="agentId">ID агента</param>
        //за всё время
        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok();
        }
        //за период времени
        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"NetworkMetricsController GetMetricsFromAgent agentId {agentId}, fromTime {fromTime}, toTime {toTime}");
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
