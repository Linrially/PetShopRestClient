using PetShopQa.Models;
using RestSharp;

namespace PetShopQa.Clients
{
    public class UserClient : RestTestClient
    {
        public static async Task<RestResponse> UserCreate(User createRequest)
        {
            var url = Url.UserCreate;
            return await Post(url, createRequest);
        }

        public static async Task<RestResponse> UserCreateWithList(List<User> userList)
        {
            var url = Url.UserCreateWithList;
            return await Post(url, userList);
        }
        
        public static async Task<RestResponse> UserCreateWithArray(User[] userArray)
        {
            var url = Url.UserCreateWithArray;
            return await Post(url, userArray);
        }
        
        public static async Task<RestResponse> UserLogin(LoginUserRequest loginUserRequest)
        {
            var url = Url.UserLogin;
            return await Get(url, loginUserRequest);
        }

        public static async Task<RestResponse> UserLogout()
        {
            var url = Url.UserLogout;
            return await Get(url);
        }
        
        public static async Task<User> UserGet(string userName)
        {
            var url = Url.UserGet(userName);
            return await GetSerialize<User>(url);
        }

        public static async Task<RestResponse> UserUpdate(User update)
        {
            var url = Url.UserUpdate(update.Username);
            return await Put(url, update);
        }

        public static async Task<RestResponse> UserDelete(string userName)
        {
            var url = Url.UserDelete(userName);
            return await Delete(url);
        }
    }
}