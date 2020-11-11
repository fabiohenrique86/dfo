using DFO.User.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFO.User.Repository
{
    public interface IUserRepository
    {
        void Create(UserDto userDto);
        void Update(UserDto userDto);
        UserDto GetById(int id);
        List<UserDto> GetAll();
    }
}
