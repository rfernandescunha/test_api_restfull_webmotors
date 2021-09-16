using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebMotors.Application.Interfaces;
using WebMotors.Application.ViewModels.AnuncioWebMotors;
using WebMotors.Domain.Interfaces.IServices;

namespace WebMotors.Api.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AnuncioWebMotorsController : ControllerBase
    {
        private Itb_AnuncioWebMotorsAppServices _service;
        public AnuncioWebMotorsController(Itb_AnuncioWebMotorsAppServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os anuncios
        /// </summary>
        /// <returns>IEnumerable<tb_AnuncioWebmotors></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Find()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicita��o inv�lida
            }

            try
            {
                return Ok(await _service.Find(null).ConfigureAwait(true));

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}", Name = "FindtWithId")]
        public async Task<ActionResult> Find(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Find(id).ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        /// <returns>Retorno dados do anuncio criado</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Insert([FromBody] AnuncioWebMotorsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _service.Insert(model).ConfigureAwait(true);

                if (result != null)
                {
                    return Created(new Uri(Url.Link("FindtWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] AnuncioWebMotorsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Update(model).ConfigureAwait(true);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id).ConfigureAwait(true));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
