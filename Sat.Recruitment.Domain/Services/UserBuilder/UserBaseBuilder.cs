using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services.Contracts;

namespace Sat.Recruitment.Domain.Services.UserBuilder
{
    public abstract class UserBaseBuilder
    {
        protected readonly IUserModel ModelUserModel;
        private readonly IEmailNormalize _emailNormalize;

        protected UserBaseBuilder(IUserModel modelUserModel, IEmailNormalize emailNormalize)
        {
            ModelUserModel = modelUserModel;
            _emailNormalize = emailNormalize;
        }

        public User Build()
        {
            return new User
            {
                Name = ModelUserModel.Name,
                Email = _emailNormalize.Normalize(ModelUserModel.Email),
                Address = ModelUserModel.Address,
                Phone = ModelUserModel.Phone,
                UserType = ModelUserModel.UserType,
                Money = GetUpdatedMoneyValue()
            };
        }

        public abstract decimal GetUpdatedMoneyValue();
    }
}