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
    public class UpdateWorkflowUseCase : IUpdateWorkflowUseCase
    {
        private readonly IRulesEngineApiGateway _gateway;

        public UpdateWorkflowUseCase(IRulesEngineApiGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<WorkflowResponse> ExecuteAsync(WorkflowDomain workflow)
        {
            DateTime currentDateTime = DateTime.UtcNow;

            workflow.LastUpdatedAt = currentDateTime;

            await _gateway.UpdateAsync(workflow).ConfigureAwait(false);
            return workflow.ToResponse();
        }
    }
}
