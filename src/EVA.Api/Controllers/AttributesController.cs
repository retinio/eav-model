using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVA.Api.Controllers.Commands.Attributes.Create;
using EVA.Api.Controllers.Commands.Attributes.Delete;
using EVA.Api.Controllers.Commands.Attributes.Update;
using EVA.Api.Controllers.Queries.Attributes;
using EVA.Application.Dto;
using EVA.Application.Dto.Attribute;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EVA.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/attributes")]
    [SwaggerTag("Create, read, update and delete atribute")]
    public class AttributesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttributesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Get attribute list
        /// </summary>        
        /// <response code="200">attribute list</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> GetAttributes()
        {
            var result = await _mediator.Send(new AttributesQuery());
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// Create new attribute
        /// </summary>        
        /// <response code="200">New attribute created successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, type: typeof(AttributeWithIdentityDto))]
        public async Task<IActionResult> CreateAttribute([FromBody] AttributeDto dto)
        {
            var result = await _mediator.Send(new CreateAttributeCommand(dto));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// Update attribute data
        /// </summary>        
        /// <response code="200">Attribute data updated successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [SwaggerResponse(200, type: typeof(AttributeWithIdentityDto))]
        public async Task<IActionResult> UpdateAttribute([FromRoute] Guid id, [FromBody] AttributeWithOutTypeDto dto)
        {
            var result = await _mediator.Send(new UpdateAttributeCommand(id, dto));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// Delete attribute
        /// </summary>        
        /// <response code="200">Attribute deleted successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(200, type: typeof(ResultSuccessDto))]
        public async Task<IActionResult> DeleteAttribute([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteAttributeCommand(id));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }
    }
}