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
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsRepository> _mock;
        private Mock<ILogger<DotNetMetricsController>> _mockLogger;
        public DotNetMetricsControllerUnitTest()
        {
            _mock = new Mock<IDotNetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(_mockLogger.Object, _mock.Object);
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
