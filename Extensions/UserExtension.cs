using PetShopQa.Models;

namespace PetShopQa.Extensions
{
    public static class UserExtension
    {
        public static void PrintUser(this User newUser)
        {
            Console.Write("\n Id = " + newUser.Id);
            Console.Write("\n Username = " + newUser.Username);
            Console.Write("\n FirstName = " + newUser.FirstName);
            Console.Write("\n LastName = " + newUser.LastName);
            Console.Write("\n Email = " + newUser.Email);
            Console.Write("\n Password = " + newUser.Password);
            Console.Write("\n Phone = " + newUser.Phone);
            Console.Write("\n UserStatus = " + newUser.UserStatus);
            
            //TODO: logger info - print, а до того засунуть метод ToString  в класс 
        }
    }
}