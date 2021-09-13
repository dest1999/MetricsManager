using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTest
    {
        private CpuMetricsController _controller;
        private Mock<ICpuMetricsRepository> _mock;
        private Mock<ILogger<CpuMetricsController>> _mockLogger;

        public CpuMetricsControllerUnitTest()
        {
            _mock = new Mock<ICpuMetricsRepository>();
            _mockLogger = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(_mockLogger.Object, _mock.Object);
        }

        [Fact]
        public void CallCreateTest()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<BaseMetricValue>())).Verifiable();

            var result = _controller.Create(new BaseMetricValue { Time = DateTime.Now, Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<BaseMetricValue>()), Times.AtMostOnce());


            ////arange
            //TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            //TimeSpan timeTo = TimeSpan.FromSeconds(100);

            ////act
            //var result = _controller.GetMetric(timeFrom, timeTo);

            ////assert
            //Assert.IsAssignableFrom<IActionResult>(result);

        }
    }
}
