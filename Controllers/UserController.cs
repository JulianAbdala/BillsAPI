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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBillsServices _services;

        public UserController(IUserRepository repository, IMapper mapper, IBillsServices services)
        {
            _repository = repository;
            _mapper = mapper;
            _services = services;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUser()
        {
            var user = _repository.GetUser();
            return Ok(user);
        }
        [Authorize]
        [HttpGet("{id}", Name = "GetBillUser")]
        // Por id
        public ActionResult GetUser(int id)
        {
            var user = _repository.GetUser(id);
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();

            return Ok(_mapper.Map<UserDto>(user));
        }
        [HttpPost]      // Post
        public ActionResult<UserDto> CrearUser(PostUserDto createUser)
        {

            User userNuevo = _mapper.Map<User>(createUser);

            _repository.AddUser(userNuevo);
            _repository.SaveChange();

            return CreatedAtRoute(
                "GetBillAdmin",
                new
                {
                    id = userNuevo.Id,
                },
                _mapper.Map<UserDto>(userNuevo));
        }
        [HttpPut("{id}")]
        public ActionResult ActualizarUser(int id, PutUserDto userUpdated)
        {
            var user2Update = _repository.GetUser(id);
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();

            _mapper.Map(userUpdated, user2Update);

            _repository.SaveChange();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userAEliminar = _repository.GetUser(id);
            if (userAEliminar is null)
                return NotFound();
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "administrator")
                return Forbid();

            _repository.DeleteUser(id);

            _repository.SaveChange();

            return NoContent();
        }
    }
}