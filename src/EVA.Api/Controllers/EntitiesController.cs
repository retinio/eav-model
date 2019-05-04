using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EVA.Api.Controllers.Commands.Entities.Create;
using EVA.Application.Dto;
using EVA.Application.Dto.Attribute;
using EVA.Application.Dto.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EVA.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/entities")]
    [SwaggerTag("Create, read, update and delete firmwares")]
    public class EntitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntitiesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Create new entity
        /// </summary>        
        /// <response code="200">New entity created successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(200, type: typeof(IEnumerable<GuidResultSuccessDto>))]
        public async Task<IActionResult> CreateEntities([FromBody] EntityDto dto)
        {
            var result = await _mediator.Send(new CreateEntityCommand(dto));
            return result.StatusCode == 200 ? Ok(result.Result) : StatusCode(result.StatusCode, result.Errors);
        }

        /// <summary>
        /// Get entities data by type
        /// </summary>        
        /// <response code="200">Entity data list</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpGet]
        [Route("{type}")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> GetEntities([FromRoute] string type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>        
        /// <response code="200">Entity data</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> GetEntities([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
       
        /// <summary>
        /// Delete entity
        /// </summary>        
        /// <response code="200">Entity deleted successful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> DeleteEntity([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new attribute to entity
        /// </summary>        
        /// <response code="200">Attribute added succesful</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/atributes")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> CreateEntityAttributes([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update data attribute of entity
        /// </summary>        
        /// <response code="200">attribute list</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/atributes}")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> UpdateEntityAttributes([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete attribute from entity
        /// </summary>        
        /// <response code="200">attribute list</response>
        /// <response code="400">Handle some error</response>        
        /// <response code="500">Smth go wrong...</response>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/atributes/{name}")]
        [SwaggerResponse(200, type: typeof(IEnumerable<AttributeWithIdentityDto>))]
        public async Task<IActionResult> DeleteEntityAttributes([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}