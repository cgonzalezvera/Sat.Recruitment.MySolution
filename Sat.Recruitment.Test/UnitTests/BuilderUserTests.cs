using Moq;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Services.UserBuilder;
using Xunit;

namespace Sat.Recruitment.Test.UnitTests
{
    public class BuilderUserTests
    {
        [Fact]
        public void GetUpdatedMoneyValue_NormalUserWithMoney101_Return113_12()
        {
            // ARRANGE
            const decimal moneyValueInitial=101;
            var mockUserModel = new Mock<IUserModel>();
            mockUserModel.SetupGet(x => x.Money).Returns(moneyValueInitial);
            var userNormal = new NormalUserBuilder(mockUserModel.Object,null);
            var expectedValue = 113.12m;
            // ACT
            var moneyUpdated = userNormal.GetUpdatedMoneyValue();
            // ASSERT
            Assert.True(moneyUpdated == expectedValue);
        }
        
        [Fact]
        public void GetUpdatedMoneyValue_NormalUserWithMoneyBetween10and100_Return36()
        {
            // ARRANGE
            const decimal moneyValueInitial=20;
            var mockUserModel = new Mock<IUserModel>();
            mockUserModel.SetupGet(x => x.Money).Returns(moneyValueInitial);
            var userNormal = new NormalUserBuilder(mockUserModel.Object,null);
            var expectedValue = 36.0m;
            // ACT
            var moneyUpdated = userNormal.GetUpdatedMoneyValue();
            // ASSERT
            Assert.True(moneyUpdated == expectedValue);
        }
        
        [Fact]
        public void GetUpdatedMoneyValue_NormalUserWithMoney5_Return5()
        {
            // ARRANGE
            const decimal moneyValueInitial=5;
            var mockUserModel = new Mock<IUserModel>();
            mockUserModel.SetupGet(x => x.Money).Returns(moneyValueInitial);
            var userNormal = new NormalUserBuilder(mockUserModel.Object,null);
            // ACT
            var moneyUpdated = userNormal.GetUpdatedMoneyValue();
            // ASSERT
            Assert.True(moneyUpdated == moneyValueInitial);
        }
        
        
        [Fact]
        public void GetUpdatedMoneyValue_SuperUserWithMoney101_Return181_8()
        {
            // ARRANGE
            const decimal moneyValueInitial=101;
            var mockUserModel = new Mock<IUserModel>();
            mockUserModel.SetupGet(x => x.Money).Returns(moneyValueInitial);
            var userNormal = new SuperUserBuilder(mockUserModel.Object,null);
            var expectedValue = 181.8m;
            // ACT
            var moneyUpdated = userNormal.GetUpdatedMoneyValue();
            // ASSERT
            Assert.True(moneyUpdated == expectedValue);
        }
        
        
        [Fact]
        public void GetUpdatedMoneyValue_PremiumUserWithMoney110_Return198()
        {
            // ARRANGE
            const decimal moneyValueInitial=110;
            var mockUserModel = new Mock<IUserModel>();
            mockUserModel.SetupGet(x => x.Money).Returns(moneyValueInitial);
            var userNormal = new SuperUserBuilder(mockUserModel.Object,null);
            var expectedValue = 198m;
            // ACT
            var moneyUpdated = userNormal.GetUpdatedMoneyValue();
            // ASSERT
            Assert.True(moneyUpdated == expectedValue);
        }
    }
}