using AutoMapper;
using DesafioBackEnd.Application.Interfaces;
using DesafioBackEnd.Application.ViewModels;
using DesafioBackEnd.Application.ViewModels.Rental;
using DesafioBackEnd.Core.Extensions;
using DesafioBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMapper _mapper;
        public MotorcycleController(IHttpContextAccessor httpContextAccessor, IMapper mapper, IMotorcycleService motorcycleService)
        {
            _mapper = mapper;
            _motorcycleService = motorcycleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var motorcycles = _motorcycleService.GetAllAsync();

                var retorno = _mapper.Map<List<RentalResponseViewModel>>(motorcycles);

                return Ok(new ResultViewModel<List<RentalResponseViewModel>>(retorno));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Motorcycle>>("05X04 - Falha interna no servidor"));
            }
        }


        [HttpGet("{licensePlate:string}")]
        public async Task<IActionResult> GetByLicensePlateAsync(
            [FromRoute] string licensePlate)
        {
            try
            {
                var motorcycle = await _motorcycleService.GetByLicensePlateAsync(licensePlate);

                var retorno = _mapper.Map<RentalResponseViewModel>(motorcycle);

                return Ok(new ResultViewModel<RentalResponseViewModel>(retorno));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] MotorcycleViewModel model
            )
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Motorcycle>(ModelState.GetErrors()));

            try
            {
                var motorcycle = new Motorcycle(model.Year, model.Model, model.LicensePlate);

                await _motorcycleService.AddAsync(motorcycle);


                var retorno = _mapper.Map<MotorcycleResponseViewModel>(motorcycle);

                return Created($"{motorcycle.Id}", new ResultViewModel<MotorcycleResponseViewModel>(retorno));

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05XE9 - Não foi possível incluir a tarefa"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05X10 - Falha interna no servidor"));
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] Guid id,
            [FromRoute] string licensePlate
            )
        {
            try
            {
                await _motorcycleService.UpdateLicensePlateAsync(id, licensePlate);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05XE8 - Não foi possível alterar"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05X11 - Falha interna no servidor"));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id
            )
        {
            try
            {
                var motorcycle = await _motorcycleService.DeleteAsync(id);

                var retorno = _mapper.Map<MotorcycleResponseViewModel>(motorcycle);

                return Ok(new ResultViewModel<MotorcycleResponseViewModel>(retorno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05XE7 - Não foi possível excluir a tarefa"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Motorcycle>("05X12 - Falha interna no servidor"));
            }
        }

    }
}
