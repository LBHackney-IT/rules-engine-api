using System.Collections.Generic;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
