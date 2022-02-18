 resource "aws_dynamodb_table" "rulesengineapi_dynamodb_table" {
    name                  = "RulesEngine"
    billing_mode          = "PROVISIONED"
    read_capacity         = 10
    write_capacity        = 50
    hash_key              = "workflowName"

    attribute {
        name              = "workflowName"
        type              = "S"
    }

    tags = {
        Name              = "rules-engine-api-${var.environment_name}"
        Environment       = var.environment_name
        terraform-managed = true
        project_name      = var.project_name
    }    

    point_in_time_recovery {
        enabled           = true
    }
}
