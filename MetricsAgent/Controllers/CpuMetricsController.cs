using AutoMapper;
using CommonClassesLibrary;
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
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ILogger<CpuMetricsController> _logger;
        private ICpuMetricsRepository _repository;
        private IMapper _mapper;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] BaseMetricValue request)
        {
            _repository.Create(request);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var returnCollection = _mapper.Map<List<BaseMetricDTO>>(_repository.GetAllAndClearValues());
            return Ok(returnCollection);
        }

        #region //за период времени, скорее всего использоваться не будет

        //за период времени
        //URL is: localhost:port/api/metrics/cpu/from/DD.HH:MM:SS/to/DD.HH:MM:SS
        //[HttpGet("from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetric([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"CpuMetricsController GetMetric fromTime {fromTime}, toTime {toTime}");
        //    return Ok();
        //}
        #endregion


    }
}
