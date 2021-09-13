using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private ILogger<NetworkMetricsController> _logger;
        private INetworkMetricsRepository _repository;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, INetworkMetricsRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }
        public NetworkMetricsController(INetworkMetricsRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] BaseMetricValue request)
        {
            _repository.Create(new BaseMetricValue { Time = request.Time, Value = request.Value });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }


        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetric([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"NetworkMetricsController GetMetric fromTime {fromTime}, toTime {toTime}");
            return Ok();
        }
    }
}
