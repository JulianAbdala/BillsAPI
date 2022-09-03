using RatingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RatingAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using RatingAPI.Data;
using RatingAPI.Services;

namespace RatingAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/bills")]
    public class AdminController : ControllerBase
    {
        private readonly IBillsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBillsServices _services;

        public AdminController(IBillsRepository repository, IMapper mapper, IBillsServices services)
        {
            _repository = repository;
            _mapper = mapper;
            _services = services;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BillsDto>> GetBills() //JsonResults implementa IActionResults
        {
            var bills = _repository.GetBills();
            return Ok(bills);
        }

        [HttpGet("{id}", Name = "GetBillAdmin")]        // Por id
        public ActionResult GetBill(int id)
        {
            //    Entities.Bills bills = _repository.GetBills(id);
            //    if (!_repository.BillExists(id))
            //        return NotFound();
            var bills = _repository.GetBills(id);
            //if (!_repository.BillExists(id))
              //  return NotFound();


            return Ok(_mapper.Map<BillsDto>(bills));
        }

       /*[HttpPost ("search")]      // Search
        public ActionResult SearchBillsByName(string name)
        {
            var search = _repository.SearchBillsByName(name);
            if (!_repository.BillByNameExists(name))
            {
                return NotFound();
            }


            return Ok(search);
        }*/

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
           /* if (!_repository.BillExists(id))
                return NotFound();*/
            var bill2Update = _repository.GetBills(id);

            _mapper.Map(billsUpdated, bill2Update);

            _repository.SaveChange();

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public ActionResult DeleteBills(int id)
        {
            var BillAEliminar = _repository.GetBills(id);
            if (BillAEliminar is null)
                return NotFound();

            _repository.SaveChange();
            //_services.KillBill(id);

            

            return NoContent();
        }
    }
}

/*var BillAEliminar = _repository.GetBills(id);
            if (BillAEliminar is null)
                return NotFound();*/

//_services.GuardarCambios();