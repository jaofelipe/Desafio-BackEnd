using AutoMapper;
using DesafioBackEnd.Application.Services;
using DesafioBackEnd.Application.ViewModels;
using DesafioBackEnd.Core.Extensions;
using DesafioBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;
        private readonly IMapper _mapper;
        public RentalController(IMapper mapper, IRentalService service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet("{id:guid}/{returnDate}")]
        public async Task<IActionResult> CalculateTotalCostAsync([FromRoute]Guid id, 
            [FromRoute]DateTime returnDate)
        {
            try
            {
                var rental = await _service.CalculateRentalCostAsync(id, returnDate);

                var retorno = _mapper.Map<RentalResponseViewModel>(rental);

                return Ok(new ResultViewModel<RentalResponseViewModel>(retorno));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Rental>("05X04 - Falha interna no servidor"));
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RentalViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<RentalViewModel>(ModelState.GetErrors()));

            try
            {

                var rental = await _service.AddAsync(model.DeliveryPersonId, model.LicensePlate, model.RentalPlan);

                var rentalIncluded = await _service.GetByIdIncludedAsync(rental.Id);

                var retorno = _mapper.Map<RentalResponseViewModel>(rentalIncluded);

                return Created($"{rental.Id}", new ResultViewModel<RentalResponseViewModel>(retorno));

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<RentalViewModel>("05XE9 - Não foi possível incluir."));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<RentalViewModel>(e.Message));
            }
        }
    }
}
