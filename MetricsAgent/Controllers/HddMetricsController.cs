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
    [Route("api/metrics/hdd/left")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private ILogger<HddMetricsController> _logger;
        private IHddMetricsRepository _repository;
        private IMapper _mapper;
        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает заполненность HDD за всё время использования
        /// </summary>
        /// <returns>
        /// DTO заполненности HDD в коллекции
        /// </returns>
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
        //    _logger.LogInformation($"HDDMetricsController GetMetric fromTime {fromTime}, toTime {toTime}");
        //    return Ok();
        //}
    }
}
