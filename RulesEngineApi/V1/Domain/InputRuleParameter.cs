using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RulesEngineApi.V1.Domain
{
    public class InputRuleParameter
    {
        public string InputRuleName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}
