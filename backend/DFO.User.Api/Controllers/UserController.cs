using DFO.User.Business;
using DFO.User.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DFO.User.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _iUserBusiness;

        public UserController(IUserBusiness iUserBusiness)
        {
            _iUserBusiness = iUserBusiness;
        }

        // GET Api/User/GetAll
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return _iUserBusiness.GetAll();
        }

        // GET Api/User/GetById/5
        [HttpGet("getById/{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            return _iUserBusiness.GetById(id);
        }

        // POST Api/User/Create
        [HttpPost("create")]
        public ActionResult<IEnumerable<UserDto>> Create([FromBody] UserDto userDto)
        {
            _iUserBusiness.Create(userDto);
            return _iUserBusiness.GetAll();
        }

        // POST Api/User/Update
        [HttpPost("update")]
        public ActionResult<IEnumerable<UserDto>> Update([FromBody] UserDto userDto)
        {
            _iUserBusiness.Update(userDto);
            return _iUserBusiness.GetAll();
        }
    }
}
