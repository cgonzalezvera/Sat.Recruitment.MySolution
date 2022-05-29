using Sat.Recruitment.Domain.Services;
using Xunit;

namespace Sat.Recruitment.Test.UnitTests
{
    public class EmailNormalizeTests
    {

        [Fact]
        public void Normalize_EmailWithPlus_ReturnWithoutPlusAndRest()
        {
            var emailValue = "cgonzalez+vera@gmail.com";
            var emailNormalService = new DefaultNormalizeEmail();

            var result = emailNormalService.Normalize(emailValue);
            
            Assert.True(result=="cgonzalez@gmail.com");
            
        }
        
        [Fact]
        public void Normalize_EmailWithDot_ReturnWithoutDot()
        {
            var emailValue = "cgonzalez.vera@gmail.com";
            var emailNormalService = new DefaultNormalizeEmail();

            var result = emailNormalService.Normalize(emailValue);
            
            Assert.True(result=="cgonzalezvera@gmail.com");
            
        }
    }
}