using System;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services.Contracts;
using Sat.Recruitment.Domain.Services.UserBuilder;

namespace Sat.Recruitment.Domain.Services
{
    public sealed class UserBuilderDirectorDefaultService : IUserBuilderDirectorService
    {
        private readonly IEmailNormalize _emailNormalize;
        private IUserModel _userModelBase;

        public UserBuilderDirectorDefaultService(IEmailNormalize emailNormalize)
        {
            _emailNormalize = emailNormalize;
        }
        public User GetResult()
        {
            return _userModelBase.UserType switch
            {
                UserType.Normal => new NormalUserBuilder(_userModelBase,_emailNormalize).Build(),
                UserType.SuperUser => new SuperUserBuilder(_userModelBase,_emailNormalize).Build(),
                UserType.Premium => new PremiumUserBuilder(_userModelBase,_emailNormalize).Build(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public void PrepareBuilder(IUserModel userModelBase)
        {
            _userModelBase = userModelBase;
        }
    }
}