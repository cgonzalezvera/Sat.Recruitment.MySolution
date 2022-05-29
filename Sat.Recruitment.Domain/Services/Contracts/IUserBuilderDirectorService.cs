using Sat.Recruitment.Domain.Contracts;

namespace Sat.Recruitment.Domain.Services.Contracts
{
    public interface IUserBuilderDirectorService
    {
        User GetResult();
        void PrepareBuilder(IUserModel dto);
    }
}