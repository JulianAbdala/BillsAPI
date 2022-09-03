using RatingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RatingAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using RatingAPI.Data;
using RatingAPI.Services;
using System.Security.Claims;

namespace RatingAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/bills")]
    public class BillsController : ControllerBase
    {
        private readonly IBillsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBillsServices _services;

        public BillsController(IBillsRepository repository, IMapper mapper, IBillsServices services)
        {
            _repository = repository;
            _mapper = mapper;
            _services = services;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BillsDto>> GetBills()
        {
            var bills = _repository.GetBills();
            return Ok(bills);
        }

        [HttpGet("{id}", Name = "GetBillAdmin")]        // Por id
        public ActionResult GetBill(int id)
        {
            var bills = _services.GetBills(id);


            return Ok(_mapper.Map<BillsDto>(bills));
        }

        [HttpPost ("search")]      // Search
        public ActionResult SearchBillsByName(string name)
        {
            var minName = name.ToLower();
            var search = _repository.SearchBillsByName(name).Where(c => c.Nombre.ToLower() == minName);
            if (!_repository.BillByNameExists(name))
            {
                return NotFound();
            }


            return Ok(search);
        }
        [HttpPost]      // Post
        public ActionResult<BillsDto> CrearBill(PostBillsDto createBill)
        {

            Bills billsNuevo = _mapper.Map<Bills>(createBill); 

            _repository.AddBills(billsNuevo);
            _repository.SaveChange();

            return CreatedAtRoute(
                "GetBillAdmin", 
                new 
                {
                    id = billsNuevo.Id,
                },
                _mapper.Map<BillsDto>(billsNuevo));
        }
        
        [HttpPut("{id}")]
        public ActionResult ActualizarBill(int id, PutBillsDto billsUpdated)
        {
            var bill2Update = _repository.GetBills(id);
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();

            _mapper.Map(billsUpdated, bill2Update);

            _repository.SaveChange();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public ActionResult DeleteBills(int id)
        {
            var billAEliminar = _repository.GetBills(id);
            if (billAEliminar is null)
                return NotFound();

            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();

            _services.DeleteBills(id);

            _repository.SaveChange();

            return NoContent();
        }
    }
}