using System;
using Sat.Recruitment.Api.Domain.Services;
using Sat.Recruitment.Api.Domain.Services.Contracts;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services.UserBuilder;

namespace Sat.Recruitment.Domain.Services
{
    public sealed class UserBuilderDirectorDefaultService : IUserBuilderDirectorService
    {
        private IUserModel _userModelBase;

        public User GetResult()
        {
            return _userModelBase.UserType switch
            {
                UserType.Normal => new NormalUserBuilder(_userModelBase).Build(),
                UserType.SuperUser => new SuperUserBuilder(_userModelBase).Build(),
                UserType.Premium => new PremiumUserBuilder(_userModelBase).Build(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void PrepareBuilder(IUserModel userModelBase)
        {
            _userModelBase = userModelBase;
        }
    }
}