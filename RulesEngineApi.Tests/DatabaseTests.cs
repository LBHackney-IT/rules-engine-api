using RulesEngineApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;

namespace RulesEngineApi.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private IDbContextTransaction _transaction;
        protected RulesEngineContext DatabaseContext { get; private set; }

        [SetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(ConnectionString.TestDatabase());
            DatabaseContext = new RulesEngineContext(builder.Options);

            DatabaseContext.Database.EnsureCreated();
            _transaction = DatabaseContext.Database.BeginTransaction();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
