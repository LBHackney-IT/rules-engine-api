using RulesEngineApi.V1.Gateways;
using RulesEngineApi.V1.UseCase;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;

namespace RulesEngineApi.Tests.V1.UseCase
{
    public class GetByIdUseCaseTests : LogCallAspectFixture
    {
        private Mock<IRulesEngineApiGateway> _mockGateway;
        private GetByIdUseCase _classUnderTest;

        [SetUp]
        public void SetUp()
        {
            _mockGateway = new Mock<IRulesEngineApiGateway>();
            _classUnderTest = new GetByIdUseCase(_mockGateway.Object);
        }

        //TODO: test to check that the use case retrieves the correct record from the database.
        //Guidance on unit testing and example of mocking can be found here https://github.com/LBHackney-IT/lbh-rules-engine-api/wiki/Writing-Unit-Tests
    }
}
