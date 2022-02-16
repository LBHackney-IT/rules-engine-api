using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Boundary.Request
{
    public class WorkflowRequest : Workflow
    {
        public new string WorkflowName { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> GlobalParams { get; set; }
    }
}
