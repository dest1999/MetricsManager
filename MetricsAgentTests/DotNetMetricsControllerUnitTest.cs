using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTest
    {
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsRepository> _mock;
        public DotNetMetricsControllerUnitTest()
        {
            _mock = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsController(_mock.Object);
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
