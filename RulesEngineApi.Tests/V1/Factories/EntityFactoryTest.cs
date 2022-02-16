using AutoFixture;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace RulesEngineApi.Tests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        //TODO: add assertions for all the fields being mapped in `EntityFactory.ToDomain()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<RulesEngineDbEntity>();
            var entity = databaseEntity.ToDomain();

            databaseEntity.Id.Should().Be(entity.Id);
            databaseEntity.CreatedAt.Should().BeSameDateAs(entity.CreatedAt);
        }

        //TODO: add assertions for all the fields being mapped in `EntityFactory.ToDatabase()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Test]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<Entity>();
            var databaseEntity = entity.ToDatabase();

            entity.Id.Should().Be(databaseEntity.Id);
            entity.CreatedAt.Should().BeSameDateAs(databaseEntity.CreatedAt);
        }
    }
}
