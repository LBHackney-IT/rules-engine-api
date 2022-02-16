using AutoFixture;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Infrastructure;

namespace RulesEngineApi.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static RulesEngineDbEntity CreateDatabaseEntity()
        {
            var entity = new Fixture().Create<Entity>();

            return CreateDatabaseEntityFrom(entity);
        }

        public static RulesEngineDbEntity CreateDatabaseEntityFrom(Entity entity)
        {
            return new RulesEngineDbEntity
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
            };
        }
    }
}
