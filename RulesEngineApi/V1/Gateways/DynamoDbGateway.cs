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

        public async Task AddAsync(WorkflowData workflow)
        {
            if (workflow == null)
                throw new ArgumentNullException($"{nameof(workflow)} shouldn't be null!");

            await _dynamoDbContext.SaveAsync(workflow.ToDatabase()).ConfigureAwait(false);
        }
    }
}
