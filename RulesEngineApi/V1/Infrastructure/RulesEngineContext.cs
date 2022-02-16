using Microsoft.EntityFrameworkCore;

namespace RulesEngineApi.V1.Infrastructure
{

    public class RulesEngineContext : DbContext
    {

        public RulesEngineContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RulesEngineDbEntity> RulesEngineEntities { get; set; }
    }
}
