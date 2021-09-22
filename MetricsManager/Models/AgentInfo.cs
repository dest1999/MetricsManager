using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models
{
    public class AgentInfo
    {
        private Uri _agentUri;

        public int AgentId { get; set; }
        public Uri AgentUri { 
            get => _agentUri;
            set => _agentUri = new Uri(value.ToString());
        }
        public AgentInfo()
        {

        }
    }
}
