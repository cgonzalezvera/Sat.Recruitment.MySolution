using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.ApplicationServices.DataObjects;
using Sat.Recruitment.Domain;

namespace Sat.Recruitment.ApplicationServices.Contracts
{
    public interface IUserService
    {
        Task<(bool duplicated,  string resultMessage)> CreateUser(CreateUserModelDto modelDto);
    }
}