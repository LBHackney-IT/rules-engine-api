using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RulesEngine.Models;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Infrastructure
{
    [DynamoDBTable("RulesEngine", LowerCamelCaseProperties = true)]
    public class RulesEngineDbEntity
    {
        [DynamoDBProperty(AttributeName = "id")]
        public Guid Id { get; set; }

        [DynamoDBHashKey]
        [DynamoDBProperty(AttributeName = "workflowName")]
        public string WorkflowName { get; set; }

        [DynamoDBProperty(AttributeName = "rules", Converter = typeof(DynamoDbObjectListConverter<Rule>))]
        public IEnumerable<Rule> Rules { get; set; }

        [DynamoDBProperty(AttributeName = "globalParams", Converter = typeof(DynamoDbObjectListConverter<ScopedParam>))]
        public IEnumerable<ScopedParam> GlobalParams { get; set; }

        [DynamoDBProperty(AttributeName = "createdAt", Converter = typeof(DynamoDbDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [DynamoDBProperty(AttributeName = "lastUpdatedAt", Converter = typeof(DynamoDbDateTimeConverter))]
        public DateTime? LastUpdatedAt { get; set; }
    }
}
