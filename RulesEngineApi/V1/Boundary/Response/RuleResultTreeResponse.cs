using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Boundary.Response
{
    public class RuleResultTreeResponse
    {
        /// <summary>
        /// Gets or sets the rule.
        /// </summary>
        /// <value>
        /// The rule.
        /// </value>
        public RuleResponse Rule { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets the exception message in case an error is thrown during rules calculation.
        /// </summary>
        public string ExceptionMessage { get; set; }
    }
}
