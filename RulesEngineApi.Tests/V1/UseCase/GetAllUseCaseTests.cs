using System.Linq;
using AutoFixture;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Gateways;
using RulesEngineApi.V1.UseCase;
using FluentAssertions;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace RulesEngineApi.Tests.V1.UseCase
{
    public class GetAllUseCaseTests : LogCallAspectFixture
    {
        //private Mock<IRulesEngineApiGateway> _mockGateway;
        //private UpdateWorkflowUseCase _classUnderTest;
        //private Fixture _fixture;

        //[SetUp]
        //public void SetUp()
        //{
        //    _mockGateway = new Mock<IRulesEngineApiGateway>();
        //    _classUnderTest = new CreateWorkflowUseCase(_mockGateway.Object);
        //    _fixture = new Fixture();
        //}

        //[Test]
        //public void GetsAllFromTheGateway()
        //{
        //    var stubbedEntities = _fixture.CreateMany<Entity>().ToList();
        //    _mockGateway.Setup(x => x.GetAll()).Returns(stubbedEntities);

        //    var expectedResponse = new ResponseObjectList { ResponseObjects = stubbedEntities.ToResponse() };

        //    _classUnderTest.Execute().Should().BeEquivalentTo(expectedResponse);
        //}

        ////TODO: Add extra tests here for extra functionality added to the use case
    }
}
