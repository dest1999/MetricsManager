using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _controller;

        public NetworkMetricsControllerUnitTest()
        {
            _controller = new();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //arange
            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetMetric(timeFrom, timeTo);

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);

        }
    }
}
