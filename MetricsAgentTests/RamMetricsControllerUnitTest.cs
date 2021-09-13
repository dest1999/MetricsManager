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
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController _controller;
        private Mock<IRamMetricsRepository> _mock;
        private Mock<ILogger<RamMetricsController>> _mockLogger;
        public RamMetricsControllerUnitTest()
        {
            _mock = new Mock<IRamMetricsRepository>();
            _mockLogger = new Mock<ILogger<RamMetricsController>>();
            _controller = new RamMetricsController(_mockLogger.Object, _mock.Object);
        }

        [Fact]
        public void CallCreateTest()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<BaseMetricValue>())).Verifiable();

            var result = _controller.Create(new BaseMetricValue { Time = DateTime.Now, Value = 50 });

            _mock.Verify(repository => repository.Create(It.IsAny<BaseMetricValue>()), Times.AtMostOnce());

        }
    }
}
