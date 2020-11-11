using DFO.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DFO.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private static List<UserDto> _database = new List<UserDto>();

        public void Create(UserDto userDto)
        {
            _database.Add(new UserDto()
            {
                Id = new Random().Next(1, 1000000),
                Name = userDto.Name,
                Address = userDto.Address,
                Age = userDto.Age
            });
        }

        public List<UserDto> GetAll()
        {
            return _database;
        }

        public UserDto GetById(int id)
        {
            return _database.FirstOrDefault(x => x.Id == id);
        }

        public void Update(UserDto userDto)
        {
            var user = _database.FirstOrDefault(x => x.Id == userDto.Id);

            user.Name = string.IsNullOrEmpty(userDto.Name) ? user.Name : userDto.Name;
            user.Age = userDto.Age < 0 ? user.Age : userDto.Age;
            user.Address = string.IsNullOrEmpty(userDto.Address) ? user.Address : userDto.Address;
        }
    }
}
