using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SundownBoulevard.Data.User;
using SundownBoulevard.Dtos.User;
using SundownBoulevard.Models.User;

namespace SundownBoulevard.Controllers.User
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/users
        [HttpGet("users")]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _repository.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }
        
        //GET api/users/{id}
        [HttpGet("users/{id}", Name="GetUserById")]
        public ActionResult<UserReadDto> GetUserById(string id)
        {
            var user = _repository.GetUserById(id);

            if (user != null)
            {
                return Ok(_mapper.Map<UserReadDto>(user));
            }
            else
            {
                return NotFound();
            }
        }
        
        //POST api/users
        [HttpPost("users")]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<UserModel>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new {Id = userReadDto.Id}, userReadDto);

        }
        
        //PUT api/users/{id}
        [HttpPut("users/{id}")]
        public ActionResult UpdateUser(string id, UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);

            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(userUpdateDto, userModelFromRepo);
                _repository.UpdateUser(userModelFromRepo);
                _repository.SaveChanges();

                return NoContent();
            }
        }
        
        //PATCH api/users{id}
        [HttpPatch("users/{id}")]
        public ActionResult PartialUserUpdate(string id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var userModelFromRepo = _repository.GetUserById(id);

            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
                patchDoc.ApplyTo(userToPatch, ModelState);

                if (!TryValidateModel(userToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(userToPatch, userModelFromRepo);
                    _repository.UpdateUser(userModelFromRepo);
                    _repository.SaveChanges();

                    return NoContent();
                }
            }
        }
        
        //DELETE api/users/{id}
        [HttpDelete("users/{id}")]
        public ActionResult DeleteUser(string id)
        {
            var userModelFromRepo = _repository.GetUserById(id);

            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteUser(userModelFromRepo);
                _repository.SaveChanges();

                return NoContent();
            }
        }
    }
}