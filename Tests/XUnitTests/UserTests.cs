using System.Net;
using PetShopQa.Clients;
using PetShopQa.Extensions;
using PetShopQa.Messages;
using PetShopQa.Models;
using Shouldly;
using Xunit;

namespace PetShopQa.Tests.XUnitTests
{
    public class UserTests(Setup setup) : BaseXUnitTest(setup)
    {
        [Fact] //пользователь создается, используем пока созданного
        public async Task CreateUser()
        {
            var createRequest = User.Create();
            var createUserResponse = await UserClient.UserCreate(createRequest);
            
            createUserResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }

        [Fact] //вход работает
        public async Task LoginUser() 
        {
            var loginRequest = LoginUserRequest.Create(User.Username, User.Password);
            var loginResponse = await UserClient.UserLogin(loginRequest);
            
            loginResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
            var expiredAt = loginResponse.Headers.Where(parameter => parameter.Name == "X-Expires-After")
                .Single().Value.ToString();
            Console.WriteLine("X-Expires-After: (utc) " + expiredAt);
            Console.WriteLine(loginResponse.Content);
        }

        [Fact] //logout работает
        public async Task LogoutUser()
        {
            var logoutResponse = await UserClient.UserLogout();
            
            logoutResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }

        [Fact] 
        public async Task DeleteUser()
        {
            var createRequest = User.Create(22, "Name");
            await UserClient.UserCreate(createRequest).Result.IsRestResponseSuccessful();

            var deleteResponse = await UserClient.UserDelete(createRequest.Username);
            
            deleteResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task DeleteInvalidUser()
        {
            var deleteResponse = await UserClient.UserDelete("1");
            
            deleteResponse.StatusCode.ShouldBe(HttpStatusCode.NotFound, AssertMsg.ResponseIsUnsuccessful());
        }

        [Fact]
        public async Task UpdateUser()
        {
            var updateRequest = User.Create(userName: User.Username);
            var updateResponse = await UserClient.UserUpdate(updateRequest);
            
            updateResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }

        [Fact]
        public async Task GetUser()
        {
            var getUserResponse = await UserClient.UserGet(User.Username);
            getUserResponse.PrintUser();
            
            getUserResponse.Id.ShouldBe(User.Id, AssertMsg.ParameterIsWrong("User id"));
        }

        [Fact]
        public async Task CreateWithList()
        {
            var createUserListResponse = await UserClient.UserCreateWithList(
                new List<User>() {User.Create(), User.Create()});
            
            createUserListResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task CreateWithArray()
        {
            var createUserArrayResponse = await UserClient.UserCreateWithArray(
                new User[]{User.Create(), User.Create()});
            
            createUserArrayResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
    }
}