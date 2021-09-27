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


        /// <summary>
        /// Получает метрики загрузки процессора за всё время использования
        /// </summary>
        /// <returns>
        /// DTO нагрузки процессора в коллекции
        /// </returns>
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var returnCollection = _mapper.Map<List<BaseMetricDTO>>(_repository.GetAllAndClearTable());
            return Ok(returnCollection);
        }

        #region //методы скорее всего использоваться не будут
        //[HttpPost("create")] неприменимо
        //public IActionResult Create([FromBody] BaseMetricValue request)
        //{
        //    _repository.Create(request);
        //    return Ok();
        //}

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
