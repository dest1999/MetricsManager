using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Models;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private AgentsStore _agentsStore;

        public AgentsController(AgentsStore agentsStore)
        {
            _agentsStore = agentsStore;
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
            _agentsStore.AddNewAgent(agentInfo);
            return Ok();
        }
        
        [HttpGet("agentslist")]
        public IActionResult GetAgentsList()
        {
            return Ok(_agentsStore.GetAgents());
        }

    }
}
