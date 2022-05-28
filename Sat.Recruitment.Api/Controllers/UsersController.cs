﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Omu.ValueInjecter;
using Sat.Recruitment.Api.ApiModels;
using Sat.Recruitment.ApplicationServices.Contracts;
using Sat.Recruitment.ApplicationServices.DataObjects;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/ping")]
        public async Task<string> Test()
        {
            return await Task.Run(() => "pong");
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser([FromBody] CreateUserRequest model)
        {
            // improvements nice to have
            //https://kevsoft.net/2020/02/09/adding-errors-to-model-state-and-returning-bad-request-within-asp-net-core-3-1.html
            //https://docs.microsoft.com/en-us/answers/questions/620570/net-core-web-api-model-validation-error-response-t.html
            if (!ModelState.IsValid)
            {
                return CreateErrorParameters(ModelState.Values);
            }

            var dto = new CreateUserModelDto();
            dto.InjectFrom(model);

            try
            {
                var (isDuplicated, resultMessage) = await _userService.CreateUser(dto);
                Debug.WriteLine(resultMessage);

                return new Result()
                {
                    IsSuccess = !isDuplicated,
                    Errors = resultMessage
                };
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return new Result()
                {
                    IsSuccess = false,
                    Errors = err.Message
                };
            }
        }

        private Result CreateErrorParameters(ModelStateDictionary.ValueEnumerable modelStateValues)
        {
           var errors = modelStateValues
                .SelectMany(r => r.Errors)
                .Select(r => r.ErrorMessage)
                .Aggregate(string.Empty, (p, s) => $"{p} {s}");

            return new Result()
            {
                IsSuccess = false,
                Errors = errors
            };
        }
    }
}