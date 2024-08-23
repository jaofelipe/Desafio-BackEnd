using AutoMapper;
using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Application.ViewModels;
using DesafioBackEnd.Core.Extensions;
using DesafioBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryPersonController : ControllerBase
    {
        private readonly IDeliveryPersonService _service;
        private readonly IMapper _mapper;
        public DeliveryPersonController(IMapper mapper, IDeliveryPersonService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var motorcycles = await _service.GetAllAsync();

                var retorno = _mapper.Map<List<DeliveryPersonResponseViewModel>>(motorcycles);

                return Ok(new ResultViewModel<List<DeliveryPersonResponseViewModel>>(retorno));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Motorcycle>>("05X04 - Falha interna no servidor"));
            }
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PostAsync([FromForm] DeliveryPersonViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<DeliveryPerson>(ModelState.GetErrors()));

            try
            {
                var deliveryPerson = new DeliveryPerson(model.Name, model.Cnpj, model.BirthDate.NormalizeDate(DateTimeKind.Utc), model.LicenseType, model.DriverLicenseNumber);

                await _service.AddAsync(deliveryPerson);

                //Servicos de upload
                string filePath = model?.File is not null 
                    ? await _service.SaveCnhImageAsync(deliveryPerson.Id, model.File) : string.Empty;

                var retorno = _mapper.Map<DeliveryPersonResponseViewModel>(deliveryPerson);

                retorno.FilePath = filePath;
                return Created($"{deliveryPerson.Id}", new ResultViewModel<DeliveryPersonResponseViewModel>(retorno));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<DeliveryPerson>("05XE9 - Não foi possível incluir."));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<DeliveryPerson>(e.Message));
            }
        }

        [HttpPatch("{id:guid}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PatchAsync(
            [FromRoute] Guid id,
            [FromForm] IFormFile file
            )
        {
            try
            {
                var filePath = await _service.SaveCnhImageAsync(id, file);

                return Ok(new ResultViewModel<string>(filePath));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<DeliveryPerson>("05XE8 - Não foi possível alterar"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<DeliveryPerson>(ex.Message));
            }
        }

       

    }
}
