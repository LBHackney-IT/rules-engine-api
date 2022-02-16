using System;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineApi.V1.Domain
{
    public class ScopedParamData : ScopedParam
    {
        public int? Id { get; set; }
        
        public int Seq { get; set; }
    }
}
