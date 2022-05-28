﻿using Sat.Recruitment.Api.ApiModels;
using Sat.Recruitment.Api.Domain.Contracts;

namespace Sat.Recruitment.Api.Domain
{
    public class UserModel : IUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public decimal Money { get; set; }
    }
}