using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _controller;

        public HddMetricsControllerUnitTest()
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
