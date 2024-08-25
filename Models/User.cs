namespace PetShopQa.Models
{
    /// <summary>
    /// члены класса модели всегда public,
    /// иначе JsonSerialize (JsonConvert) не может их использовать и сериализовать
    /// </summary>
    public class User
    {
        public ulong Id { get; set; } 
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int UserStatus { get; set; }

        public static User Create(
            ulong id = 0,
            string userName = null,
            string firstName = null,
            string lastName = null,
            string email = null,
            string password = null,
            string phone = "+79657009876",
            int userStatus = 0)
        {
            userName ??= Guid.NewGuid().ToString("N");
            firstName ??= Guid.NewGuid().ToString("N");
            lastName ??= Guid.NewGuid().ToString("N");
            email ??= Guid.NewGuid().ToString("N").Substring(0,10) + "@test.com" ;
            password ??= Guid.NewGuid().ToString("N");

            return new User()
            {
                Id = id,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Phone = phone,
                UserStatus = userStatus
            };
        }
    }
}