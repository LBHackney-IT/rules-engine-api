using System;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineApi.V1.Domain
{
    public class ScopedParamData : ScopedParam
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [JsonIgnore]
        public int Seq { get; set; }
    }
}
