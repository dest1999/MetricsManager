using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTest
    {
        private RamMetricsController _controller;

        public RamMetricsControllerUnitTest()
        {
            _controller = new();
        }

        [Fact]
        public void GetMetricsFromAgentByPeriod_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(10);

            //Act
            var result = _controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromClusterByPeriod_ReturnsOk()
        {
            //Arrange
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(10);

            //Act
            var result = _controller.GetMetricsFromCluster(fromTime, toTime);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAgentByAllTime_ReturnsOk()
        {
            //Arrange
            var agentId = 1;

            //Act
            var result = _controller.GetMetricsFromAgent(agentId);

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromClusterByAllTime_ReturnsOk()
        {
            //Arrange

            //Act
            var result = _controller.GetMetricsFromCluster();

            //Assert
            Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
