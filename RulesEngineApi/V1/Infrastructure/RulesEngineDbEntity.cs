using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RulesEngineApi.V1.Domain;

namespace RulesEngineApi.V1.Infrastructure
{
    [DynamoDBTable("RulesEngine", LowerCamelCaseProperties = true)]
    public class RulesEngineDbEntity
    {
        [DynamoDBRangeKey]
        [DynamoDBProperty(AttributeName = "id")]
        public Guid Id { get; set; }

        [DynamoDBHashKey]
        [DynamoDBProperty(AttributeName = "workflowName")]
        public string WorkflowName { get; set; }

        [DynamoDBProperty(AttributeName = "rules", Converter = typeof(DynamoDbObjectListConverter<RuleData>))]
        public List<RuleData> Rules { get; set; }

        [DynamoDBProperty(AttributeName = "globalParams", Converter = typeof(DynamoDbObjectListConverter<ScopedParamData>))]
        public List<ScopedParamData> GlobalParams { get; set; }

        [DynamoDBProperty(AttributeName = "seq")]
        public int Seq { get; set; }
        
        [DynamoDBProperty(AttributeName = "createAt", Converter = typeof(DynamoDbDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}
