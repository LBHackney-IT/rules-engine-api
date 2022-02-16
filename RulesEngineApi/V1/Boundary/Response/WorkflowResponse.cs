using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Boundary.Request
{
    public class WorkflowResponse : Workflow
    {
        [JsonProperty(Order = 1)]
        public Guid Id { get; set; }

        [JsonProperty(Order = 2)]
        public new string WorkflowName { get; set; }

        [JsonProperty(Order = 3)]
        public new List<RuleData> Rules { get; set; }

        [JsonProperty(Order = 4)]
        public new List<ScopedParamData> GlobalParams { get; set; }

        [JsonProperty(Order = 5)]
        public DateTime CreatedAt { get; set; }
    }
}
