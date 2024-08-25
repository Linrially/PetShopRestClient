using PetShopQa.Models;
using Xunit;

namespace PetShopQa.Tests.XUnitTests
{
    public class BaseXUnitTest : IClassFixture<Setup>
    {
        protected Setup TestSetUp;
        protected User User;

        public BaseXUnitTest(Setup setup)
        {
            TestSetUp = setup;
            User = setup.User;
        }
    }
}