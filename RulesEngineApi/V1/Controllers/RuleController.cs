using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesEngine.Models;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Infrastructure;
using RulesEngineApi.V1.Factories;
using RulesEngineApi.V1.JsonConverters;

namespace RulesEngineApi.V1.Controllers
{
    [ApiController]
    [Route("api/v1/rule")]
    [Produces("application/json")]
    [ApiVersion("1.0")]

    public class RuleController : BaseController
    {
        private readonly IExecuteAllRulesUseCase _executeAllRulesUseCase;

        public RuleController(IExecuteAllRulesUseCase executeAllRulesUseCase)
        {
            _executeAllRulesUseCase = executeAllRulesUseCase;
        }

        /// <summary>
        /// Execute workflow rules
        /// </summary>
        /// <param name="workflowName">Workflow name to be executed</param>
        /// <param name="inputRules">Input Rule Parameters</param>
        /// <response code="200">Success. Rules executed successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RuleResultTreeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> ExecuteAllRules([FromQuery] string workflowName, [FromBody] List<InputRuleRequest> inputRules)
        {
            if (string.IsNullOrEmpty(workflowName))
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "The workflow name cannot be empty!"));
            }

            if (inputRules == null)
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "The input rules name cannot be empty!"));
            }

            var rulesResultResponses = await _executeAllRulesUseCase.ExecuteAsync(workflowName, inputRules).ConfigureAwait(false);

            if (rulesResultResponses == null)
            {
                return NotFound(new BaseErrorResponse((int) HttpStatusCode.NotFound, "The workflow by provided workflow name and input rules not found!"));
            }

            return Ok(rulesResultResponses);
        }
    }
}
