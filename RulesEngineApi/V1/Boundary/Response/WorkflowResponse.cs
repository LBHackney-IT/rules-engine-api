using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Boundary.Response
{
    public class WorkflowResponse
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the workflow name.
        /// </summary>
        public string WorkflowName { get; set; }

        /// <summary>
        /// list of rules.
        /// </summary>
        public IEnumerable<RuleResponse> Rules { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime? LastUpdatedAt { get; set; }
    }
}
