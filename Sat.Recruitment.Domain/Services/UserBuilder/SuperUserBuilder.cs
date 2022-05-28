﻿using System;
using Sat.Recruitment.Domain.Contracts;

namespace Sat.Recruitment.Domain.Services.UserBuilder
{
    public sealed class SuperUserBuilder : UserBaseBuilder
    {
        private const decimal MinMoney = 100;
        private const double Percent = 0.8;

        public SuperUserBuilder(IUserModel modelUserModel) : base(modelUserModel)
        {
        }

        public override decimal GetUpdatedMoneyValue()
        {
            var money = ModelUserModel.Money;
            if (money > MinMoney)
            {
                var percentage = Convert.ToDecimal(Percent);
                var gif = money * percentage;
                return money + gif;
            }

            return money;
        }
    }
}