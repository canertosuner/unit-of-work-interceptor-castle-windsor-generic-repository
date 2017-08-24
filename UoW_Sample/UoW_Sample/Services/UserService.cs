using System;
using UoW_Sample.Models;
using UoW_Sample.Repository;
using UoW_Sample.Request;

namespace UoW_Sample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public UserService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public void AddNewUser(AddNewUserRequest reqModel)
        {
            var user = new User { Name = reqModel.User.Name, SurName = reqModel.User.SurName };
            var userId = _userRepository.Insert(user);

            var currentUser = _userRepository.Get(userId);
            currentUser.SurName = "tosunerovich";
            _userRepository.Update(currentUser);

            var address = new Address { UserId = userId, CityCode = reqModel.Address.CityCode, Description = reqModel.Address.Description, DistrictCode = reqModel.Address.DistrictCode };
            _addressRepository.Insert(address);
        }
    }

}