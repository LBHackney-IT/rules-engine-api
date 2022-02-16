using System.Collections.Generic;
using System.Threading.Tasks;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Infrastructure;

namespace RulesEngineApi.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class RulesEngineApiGateway : IRulesEngineApiGateway
    {
        private readonly RulesEngineContext _rulesEngineDbContext;

        public RulesEngineApiGateway(RulesEngineContext rulesEngineDbContext)
        {
            _rulesEngineDbContext = rulesEngineDbContext;
        }

        public async Task AddAsync(WorkflowData workflow)
        {
            await _rulesEngineDbContext.AddAsync(workflow).ConfigureAwait(false);
        }
    }
}
