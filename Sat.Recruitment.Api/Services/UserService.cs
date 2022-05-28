﻿using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Domain.Contracts;
using Sat.Recruitment.Api.Domain.Services.Contracts;
using Sat.Recruitment.Api.Services.Contracts;
using Sat.Recruitment.Api.Services.DataObjects;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserBuilderDirectorService _userBuilderService;

        public UserService(IUserRepository userRepository, IUserBuilderDirectorService userBuilderService)
        {
            _userRepository = userRepository;
            _userBuilderService = userBuilderService;
        }

        public async Task<(bool duplicated, string resultMessage)> CreateUser(CreateUserModelDto modelDto)
        {
            _userBuilderService.PrepareBuilder(modelDto);
            var newUser = _userBuilderService.GetResult();
            var storedUsers = await _userRepository.GetAllAsync();

            var duplicated = storedUsers
                .Any(u => (u.Email == newUser.Email || u.Phone == newUser.Phone) ||
                          (u.Name == newUser.Name && u.Address == newUser.Address));

            return (duplicated, duplicated ? "The user is duplicated" : "User Created");
        }
    }
}