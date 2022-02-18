using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RulesEngineApi.V1.Domain.Enums;

namespace RulesEngineApi.V1.Boundary.Request
{
    public class RuleRequest
    {
        /// <summary>
        /// Rule name for the Rule
        /// </summary>
        public string RuleName { get; set; }

        public string Operator { get; set; }

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets whether the rule is enabled.
        /// </summary>
        public bool Enabled { get; set; } = true;

        [JsonConverter(typeof(StringEnumConverter))]
        public RuleExpressionTypeEnum RuleExpressionType { get; set; } = RuleExpressionTypeEnum.LambdaExpression;

        public IEnumerable<RuleRequest> Rules { get; set; }

        public string Expression { get; set; }

        public string SuccessEvent { get; set; }
    }
}
