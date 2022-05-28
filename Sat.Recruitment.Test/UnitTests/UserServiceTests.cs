using System.Linq;
using System.Reflection;
using Moq;
using Sat.Recruitment.ApplicationServices;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Contracts;
using Xunit;

namespace Sat.Recruitment.Test.UnitTests
{
    public class UserServiceTests
    {
        private readonly User[] _userList;
        private const string UserServiceHasSomeDuplicatedMethodName = "HasSomeDuplicated";

        public UserServiceTests()
        {
            _userList = new[]
            {
                new User
                {
                    Address = "Dir1", Email = "email1", Phone = "1111", Name = "Name1"
                },
                new User
                {
                    Address = "Dir2", Email = "email2", Phone = "2222", Name = "Name2"
                },
                new User
                {
                    Address = "Dir3", Email = "email4", Phone = "333", Name = "Name3"
                }
            };
        }
        [Fact]
        public void HasSomeDuplicated_ExistUser_ReturnTrue()
        {
            
            // ARRANGE
            var mockUserRepository = new Mock<IUserRepository>();
            var userTest = new User
            {
                Address = "Dir2", Email = "email2", Phone = "2222", Name = "Pepe"
            };

            mockUserRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(_userList.ToList());

            var userService = new UserService(mockUserRepository.Object, null);

            var methodHasSomeDuplicated = userService.GetType()
                .GetMethod(UserServiceHasSomeDuplicatedMethodName, BindingFlags.NonPublic | BindingFlags.Instance);

            // ACT

            if (methodHasSomeDuplicated == null) return;
            var isDuplicated = methodHasSomeDuplicated.Invoke(userService, new object[2] { _userList, userTest });

            // ASSERT

            Assert.Equal(true, isDuplicated);
        }


        [Fact]
        public void HasSomeDuplicated_NotExistUser_ReturnFalse()
        {
            // ARRANGE
            var mockUserRepository = new Mock<IUserRepository>();


            var userTest = new User
            {
                Address = "Dir20", Email = "email20", Phone = "2222000", Name = "Pepe"
            };
           
            mockUserRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(_userList.ToList());

            var userService = new UserService(mockUserRepository.Object, null);
            var methodHasSomeDuplicated = userService.GetType()
                .GetMethod(UserServiceHasSomeDuplicatedMethodName, BindingFlags.NonPublic | BindingFlags.Instance);

            // ACT

            if (methodHasSomeDuplicated == null) return;
            var isDuplicated = methodHasSomeDuplicated.Invoke(userService, new object[2] { _userList, userTest });
            

            // ASSERT
            Assert.Equal(false, isDuplicated);
        }
    }
}