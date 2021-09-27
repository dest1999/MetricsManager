using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/hdd/metrics")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private ILogger<HddMetricsController> _logger;
        public HddMetricsController(ILogger<HddMetricsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Получает остаток свободного пространства накопителя за всё время использования
        /// </summary>
        /// <remarks>
        /// Пример:
        /// GET api/hdd/metrics/agent/5
        /// </remarks>
        /// 
        /// <returns>
        /// Получает метрики свободного пространства накопителя за всё время работы агента
        /// </returns>
        /// <param name="agentId">ID агента</param>
        /// 
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
        //    _logger.LogInformation($"HDDMetricsController GetMetricsFromAgent agentId {agentId}, fromTime {fromTime}, toTime {toTime}");
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
