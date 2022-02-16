using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineApi.V1.Domain
{
    public class RuleData : Rule
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> LocalParams { get; set; }
        [JsonIgnore]
        public bool? IsSuccess { get; set; }
        [JsonIgnore]
        public string ExceptionMessage { get; set; }
        [JsonIgnore]
        public int Seq { get; set; }
    }
}
