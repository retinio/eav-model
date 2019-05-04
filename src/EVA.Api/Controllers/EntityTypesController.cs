using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVA.Api.Controllers.Commands.Attributes.Create;
using EVA.Api.Controllers.Commands.Attributes.Delete;
using EVA.Api.Controllers.Commands.Attributes.Update;
using EVA.Api.Controllers.Commands.EntityTypes.Create;
using EVA.Api.Controllers.Commands.EntityTypes.Delete;
using EVA.Api.Controllers.Queries.Attributes;
using EVA.Api.Controllers.Queries.EntityTypes;
using EVA.Application.Dto;
using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.EntityType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EVA.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/entities/types")]
    [SwaggerTag("Create, read, update and delete entity types")]
    public class EntityTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntityTypesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get entity types list
        /// </summary>        
        /// <response code="200">Entity type list</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(200, type: typeof(IEnumerable<EntityTypeWithIdentityDto>))]
        public async Task<IActionResult> GetEntityTypes()
        {
            var result = await _mediator.Send(new EntityTypesQuery());
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// Create new entity type
        /// </summary>        
        /// <response code="200">New entity type created successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, type: typeof(EntityTypeWithIdentityDto))]
        public async Task<IActionResult> CreateEntityType([FromBody] EntityTypeDto dto)
        {
            var result = await _mediator.Send(new CreateEntityTypeCommand(dto));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// <summary>
        /// Delete entity type
        /// </summary>        
        /// <response code="200">Entity type deleted successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(200, type: typeof(ResultSuccessDto))]
        public async Task<IActionResult> DeleteEntityType([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteEntityTypeCommand(id));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }
    }
}