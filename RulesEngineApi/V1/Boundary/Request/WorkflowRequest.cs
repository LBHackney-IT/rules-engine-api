using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Boundary.Request
{
    public class WorkflowRequest
    {
        public string WorkflowName { get; set; }
        public List<RuleRequest> Rules { get; set; }
    }
}
