using System;
using System.Collections.Generic;
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
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IRulesEngineApiGateway _gateway;

        public GetAllUseCase(IRulesEngineApiGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<List<WorkflowResponse>> ExecuteAsync()
        {
            var workflow = await _gateway.GetAllAsync().ConfigureAwait(false);
            return workflow.ToResponse();
        }
    }
}
