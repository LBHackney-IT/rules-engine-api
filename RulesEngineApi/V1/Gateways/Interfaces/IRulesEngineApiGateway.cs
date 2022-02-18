using System.Collections.Generic;
using System.Threading.Tasks;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Gateways
{
    public interface IRulesEngineApiGateway
    {
        public Task<List<WorkflowDomain>> GetAllAsync();
        public Task<WorkflowDomain> GetByWorkflowNameAsync(string workflowName);
        public Task AddAsync(WorkflowDomain workflow);
        public Task UpdateAsync(WorkflowDomain workflow);
    }
}
