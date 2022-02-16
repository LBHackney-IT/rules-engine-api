using System.Collections.Generic;
using System.Threading.Tasks;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Gateways
{
    public interface IRulesEngineApiGateway
    {
        public Task AddAsync(WorkflowData workflow);
    }
}
