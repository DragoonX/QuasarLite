using Microsoft.AspNetCore.Mvc;
using QuasarLite.DTO;
using QuasarLite.Models;
using QuasarLite.Repository;
using System.Collections.Generic;

namespace QuasarLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("getusers")]
        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _uow.userRepository.List();
            return new JsonResult(users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return new JsonResult(_uow.userRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] List<UserDto> userDtos)
        {
            foreach (var item in userDtos)
            {
                User user = new User()
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    Username = item.Username,
                    Email = item.Email,
                    Password = item.Password
                };

                var res = _uow.userRepository.FindUsername(user.Username);
                if (res == null)
                {
                    _uow.userRepository.Insert(user);
                }
            }
            _uow.Complete();
            return GetUsers();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var res = _uow.userRepository.Delete(id);
            if (res == true)
                _uow.Complete();
            return GetUsers();
        }
    }
}
