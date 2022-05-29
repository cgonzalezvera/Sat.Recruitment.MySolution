using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services.Contracts;

namespace Sat.Recruitment.Domain.Services.UserBuilder
{
    public sealed class PremiumUserBuilder : UserBaseBuilder
    {
        private const decimal MinMoney = 100;
        private const double Coefficient = 0.8;

        public PremiumUserBuilder(IUserModel modelUserModel, IEmailNormalize emailNormalize) : base(modelUserModel, emailNormalize)
        {
        }

        public override decimal GetUpdatedMoneyValue()
        {
            var money = ModelUserModel.Money;
            if (money > MinMoney)
            {
                var gif = money * (decimal) Coefficient;
                return money + gif;
            }


            return money;
        }
    }
}