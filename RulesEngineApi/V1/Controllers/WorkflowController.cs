using System.Net;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RulesEngineApi.V1.Boundary.Request;
using RulesEngineApi.V1.Domain;
using RulesEngineApi.V1.Infrastructure;
using RulesEngineApi.V1.Factories;

namespace RulesEngineApi.V1.Controllers
{
    [ApiController]
    [Route("api/v1/workflow")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    
    public class WorkflowController : BaseController
    {
        private readonly ICreateWorkflowUseCase _createWorkflowUseCase;

        public WorkflowController(ICreateWorkflowUseCase createWorkflowUseCase)
        {
            _createWorkflowUseCase = createWorkflowUseCase;
        }

        /// <summary>
        /// Create an workflow model
        /// </summary>
        /// <param name="workflow">Workflow model to create</param>
        /// <response code="201">Success. Workflow model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WorkflowResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Post(WorkflowRequest workflow)
        {
            if (workflow == null)
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "Workflow model cannot be null!"));
            }

            if (ModelState.IsValid)
            {
                var workflowResponse = await _createWorkflowUseCase.ExecuteAsync(workflow.ToDomain()).ConfigureAwait(false);

                return CreatedAtAction($"Post", new { id = workflowResponse.Id }, workflowResponse);
            }
            else
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, ModelState.GetErrorMessages()));
            }
        }
    }
}
