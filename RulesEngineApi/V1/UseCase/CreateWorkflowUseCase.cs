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
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetAllClaimantsUseCase
    public class CreateWorkflowUseCase : ICreateWorkflowUseCase
    {
        private readonly IRulesEngineApiGateway _gateway;

        public CreateWorkflowUseCase(IRulesEngineApiGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<WorkflowResponse> ExecuteAsync(WorkflowData workflow)
        {
            if (workflow == null)
                throw new ArgumentNullException($"{nameof(workflow)} ModelStateExtension shouldn't be null");

            if (workflow == null)
                throw new ArgumentNullException($"{nameof(workflow)} model shouldn't be null");
           
            DateTime currentDateTime = DateTime.UtcNow;

            workflow.Id = Guid.NewGuid();
            workflow.CreatedAt = currentDateTime;

            await _gateway.AddAsync(workflow).ConfigureAwait(false);
            return workflow.ToResponse();
        }
    }
}
