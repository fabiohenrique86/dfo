using DFO.User.Dto;
using DFO.User.Repository;
using System;
using System.Collections.Generic;

namespace DFO.User.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _iUserRepository;

        public UserBusiness(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public List<UserDto> GetAll()
        {
            return _iUserRepository.GetAll();
        }

        public UserDto GetById(int id)
        {
            return _iUserRepository.GetById(id);
        }

        public void Create(UserDto userDto)
        {
            ValidateCreate(userDto);
            _iUserRepository.Create(userDto);
        }

        public void Update(UserDto userDto)
        {
            ValidateUpdate(userDto);
            _iUserRepository.Update(userDto);
        }

        private void ValidateCreate(UserDto userDto)
        {
            if (userDto == null)
                throw new ApplicationException("user not found");

            if (string.IsNullOrEmpty(userDto.Name))
                throw new ApplicationException("name is mandatory");

            if (userDto.Name.Length > 50)
                throw new ApplicationException("maximum characters allowed for name is 50");

            if (userDto.Age <= 0)
                throw new ApplicationException("age is mandatory");

            if (!string.IsNullOrEmpty(userDto.Address))
            {
                if (userDto.Address.Length > 50)
                    throw new ApplicationException("maximum characters allowed for address is 50");
            }
        }

        private void ValidateUpdate(UserDto userDto)
        {
            if (userDto == null)
                throw new ApplicationException("user is mandatory");

            if (userDto.Id <= 0)
                throw new ApplicationException("id is mandatory");

            if (!string.IsNullOrEmpty(userDto.Name))
            {
                if (userDto.Name.Length > 50)
                    throw new ApplicationException("maximum characters allowed for name is 50");
            }
			
			if (userDto.Age < 0)
                throw new ApplicationException("age must be equal or greater than 0");
			
            if (!string.IsNullOrEmpty(userDto.Address))
            {
                if (userDto.Address.Length > 50)
                    throw new ApplicationException("maximum characters allowed for address is 50");
            }

            var userFound = _iUserRepository.GetById(userDto.Id) != null ? true : false;

            if (!userFound)
                throw new ApplicationException($"user ({userDto.Id}) not found");
        }
    }
}
