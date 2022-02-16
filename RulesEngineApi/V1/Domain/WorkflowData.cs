using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineApi.V1.Domain
{
    public class WorkflowData : Workflow
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> GlobalParams { get; set; }
        public new string WorkflowName { get; set; }
        [JsonIgnore]
        public int Seq { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
    }
}
