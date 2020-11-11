using DFO.User.Dto;
using System.Collections.Generic;

namespace DFO.User.Business
{
    public interface IUserBusiness
    {
        void Create(UserDto userDto);
        void Update(UserDto userDto);
        UserDto GetById(int id);
        List<UserDto> GetAll();
    }
}
