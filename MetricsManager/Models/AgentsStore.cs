﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class AgentsStore//TODO убрать этот класс полностью, работать с репозиторием AgentsRepo
    {
        private List<AgentInfo> _agents = new();

        public void AddNewAgent(AgentInfo agentInfo)
        {
            _agents.Add(agentInfo);
        }



        public List<AgentInfo> GetAgents()
        {
            return _agents;
        }
    }
}
