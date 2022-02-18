using System;
using Amazon.DynamoDBv2.DataModel;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.Infrastructure;
using Hackney.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Microsoft.Extensions.Configuration;
using Amazon.DynamoDBv2.Model;
using RulesEngineApi.V1.UseCase;

namespace RulesEngineApi.V1.Gateways
{
    public class DynamoDbGateway : IRulesEngineApiGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;
        private readonly IAmazonDynamoDB _amazonDynamoDb;
        private readonly IConfiguration _configuration;

        public DynamoDbGateway(IDynamoDBContext dynamoDbContext, IAmazonDynamoDB amazonDynamoDb, IConfiguration configuration)
        {
            _dynamoDbContext = dynamoDbContext;
            _amazonDynamoDb = amazonDynamoDb;
            _configuration = configuration;
        }

        public async Task<WorkflowDomain> GetByWorkflowNameAsync(string workflowName)
        {
            var result = await _dynamoDbContext.LoadAsync<RulesEngineDbEntity>(workflowName).ConfigureAwait(false);
            return result?.ToDomain();
        }

        public async Task<List<WorkflowDomain>> GetAllAsync()
        {
            var scan = new ScanRequest() { TableName = "RulesEngine" };
            var response = await _amazonDynamoDb.ScanAsync(scan).ConfigureAwait(false);
            return response.ToWorkflows();
        }

        public async Task AddAsync(WorkflowDomain workflow)
        {
            if (workflow == null)
                throw new ArgumentNullException($"{nameof(workflow)} shouldn't be null!");

            await _dynamoDbContext.SaveAsync(workflow.ToDatabase()).ConfigureAwait(false);
        }

        public async Task UpdateAsync(WorkflowDomain workflow)
        {
            if (workflow == null)
                throw new ArgumentNullException($"{nameof(workflow)} shouldn't be null!");

            await _dynamoDbContext.SaveAsync(workflow.ToDatabase()).ConfigureAwait(false);
        }
    }
}
