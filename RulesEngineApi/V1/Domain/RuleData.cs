using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineApi.V1.Domain
{
    public class RuleData : Rule
    {
        public int? Id { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> LocalParams { get; set; }
        public int Sequence { get; set; }
    }
}
