namespace PetShopQa.Models
{
    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static LoginUserRequest Create(
            string userName = null, 
            string password = null)
        {
            return new LoginUserRequest()
            {
                UserName = userName,
                Password = password
            };
        }
    }
}