using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            
        }


        /// <summary>
        /// Получает метрики загрузки процессора за всё время использования
        /// </summary>
        /// <remarks>
        /// Пример:
        /// GET api/cpu/metrics/agent/5
        /// </remarks>
        /// 
        /// <returns>
        /// Получает метрики процессора за всё время работы агента
        /// </returns>
        /// <param name="agentId">ID агента</param>
        
        //за всё время
        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        //за период времени
        //URL is: localhost:port/api/cpu/metrics/agent/1/from/DD.HH:MM:SS/to/DD.HH:MM:SS
        //[HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{

        //    _logger.LogInformation($"CpuMetricsController GetMetricsFromAgent agentId {agentId}, fromTime {fromTime}, toTime {toTime}");
        //    return Ok($"GetMetricsFromAgent method, agentId: {agentId}, fromTime: {fromTime}, toTime: {toTime}"); //возврат значений для отладки
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
