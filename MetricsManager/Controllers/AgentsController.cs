using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models;
using NLog;
using Microsoft.Extensions.Logging;
using MetricsManager.DAL;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private ILogger<AgentsController> _logger;

        //private AgentsStore _agentsStore;
        private IDBAgentsRepository _dbAgentsRepository;

        public AgentsController(IDBAgentsRepository dbAgentsRepository, ILogger<AgentsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
            _dbAgentsRepository = dbAgentsRepository;
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgent([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _logger.LogInformation($"New Agent registered with parameters: AgentId {agentInfo.AgentId}, AgentUri {agentInfo.AgentUri}");
            _dbAgentsRepository.Create(agentInfo);
            return Ok();
        }
        
        [HttpDelete("delete/{agentId}")]
        public IActionResult Delete([FromRoute] int agentId)
        {
            _dbAgentsRepository.Delete(agentId);
            return Ok();
        }

        [HttpGet("agentslist")]
        public IActionResult GetAgentsList()
        {
            return Ok(_dbAgentsRepository.GetAll());
        }

    }
}
