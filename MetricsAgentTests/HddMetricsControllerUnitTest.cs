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
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _controller;
        private Mock<IHddMetricsRepository> _mock;
        private Mock<ILogger<HddMetricsController>> _mockLogger;
        public HddMetricsControllerUnitTest()
        {
            _mock = new Mock<IHddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(_mockLogger.Object, _mock.Object);
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
