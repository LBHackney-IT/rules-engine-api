using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RulesEngineApi.V1.Boundary.Response;
using RulesEngineApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RulesEngineApi.V1.Boundary.Request;
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
        private readonly IGetAllUseCase _getAllUseCase;
        private readonly IGetByWorkflowNameUseCase _getByWorkflowNameUseCase;
        private readonly IUpdateWorkflowUseCase _updateWorkflowUseCase;

        public WorkflowController(ICreateWorkflowUseCase createWorkflowUseCase,
            IGetByWorkflowNameUseCase getByWorkflowNameUseCase,
            IGetAllUseCase getAllUseCase,
            IUpdateWorkflowUseCase updateWorkflowUseCase)
        {
            _createWorkflowUseCase = createWorkflowUseCase;
            _getAllUseCase = getAllUseCase;
            _getByWorkflowNameUseCase = getByWorkflowNameUseCase;
            _updateWorkflowUseCase = updateWorkflowUseCase;
        }

        /// <summary>
        /// Get a list of Workflow models
        /// </summary>
        /// <response code="200">Success. Workflow models was received successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Workflow cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WorkflowResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var workflows = await _getAllUseCase.ExecuteAsync().ConfigureAwait(false);

            if (workflows == null)
            {
                return NotFound();
            }

            return Ok(workflows);
        }

        /// <summary>
        /// Get an workflow model by provided workflow name.
        /// </summary>
        /// <param name="workflowName">The value by which we are looking for workflow</param>
        /// <response code="200">Success. Workflow model was received successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Workflow with provided workflow name cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WorkflowResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{workflowName}")]
        public async Task<IActionResult> GetByWorkFlowNameAsync([FromRoute] string workflowName)
        {
            if (string.IsNullOrEmpty(workflowName))
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "The workflow name cannot be empty!"));
            }

            var workflow = await _getByWorkflowNameUseCase.ExecuteAsync(workflowName).ConfigureAwait(false);

            if (workflow == null)
            {
                return NotFound(new BaseErrorResponse((int) HttpStatusCode.NotFound, "The workflow by provided workflow name not found!"));
            }

            return Ok(workflow);
        }

        /// <summary>
        /// Update an workflow model
        /// </summary>
        /// <param name="workflowName">Workflow name to be updated</param>
        /// <param name="rules">Rules model for update</param>
        /// <response code="200">Success. Workflow model was updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Workflow with provided workflow name cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(WorkflowResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status500InternalServerError)]
        [Route("{workflowName}")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromRoute] string workflowName, List<RuleRequest> rules)
        {
            if (string.IsNullOrEmpty(workflowName))
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "The workflow name cannot be empty!"));
            }

            if (rules == null)
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "Workflow model cannot be null!"));
            }

            var workflow = await _getByWorkflowNameUseCase.ExecuteAsync(workflowName).ConfigureAwait(false);

            if (workflow == null)
            {
                return NotFound(new BaseErrorResponse((int) HttpStatusCode.NotFound, "The workflow by provided workflow name not found!"));
            }

            var workflowUpdated = workflow.ToDomain();
            workflowUpdated.Rules = rules.ToDomainList();

            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, ModelState.GetErrorMessages()));
            }

            var workflowUpdatedResponse = await _updateWorkflowUseCase.ExecuteAsync(workflowUpdated).ConfigureAwait(false);

            return Ok(workflowUpdatedResponse);
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
                var existentWorkflow = await _getByWorkflowNameUseCase.ExecuteAsync(workflow.WorkflowName).ConfigureAwait(false);

                if (existentWorkflow != null)
                {
                    return BadRequest(new BaseErrorResponse((int) HttpStatusCode.BadRequest, "Workflow already exists!"));
                }

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
