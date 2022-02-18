using System;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Gateways;
using RulesEngineApi.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.UseCase
{
    public class GetByWorkflowNameUseCase : IGetByWorkflowNameUseCase
    {
        private readonly IRulesEngineApiGateway _gateway;

        public GetByWorkflowNameUseCase(IRulesEngineApiGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<WorkflowResponse> ExecuteAsync(string workflowName)
        {
            var workflow = await _gateway.GetByWorkflowNameAsync(workflowName).ConfigureAwait(false);
            return workflow?.ToResponse();
        }
    }
}
