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
    [Route("api/metrics/ram/available")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private ILogger<RamMetricsController> _logger;
        private IRamMetricsRepository _repository;
        private IMapper _mapper;
        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает метрики использования RAM за всё время использования
        /// </summary>
        /// <returns>
        /// DTO использования RAM в коллекции
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<BaseMetricDTO>>(_repository.GetAllAndClearTable()));
        }

        //[HttpPost("create")]
        //public IActionResult Create([FromBody] BaseMetricValue request)
        //{
        //    _repository.Create(request);
        //    return Ok();
        //}
        //[HttpGet("from/{fromTime}/to/{toTime}")]
        //public IActionResult GetMetric([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        //{
        //    _logger.LogInformation($"RamMetricsController GetMetric fromTime {fromTime}, toTime {toTime}");
        //    return Ok();
        //}
    }
}
