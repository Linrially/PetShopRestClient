namespace PetShopQa.Clients
{
    public static class Url
    {
        //TODO: https://petstore.swagger.io/#/ 
        
        private static string BaseUrl = "https://petstore.swagger.io/v2";

        public static string UserCreate => BaseUrl + "/user";
        public static string UserLogin => BaseUrl + "/user/login";
        public static string UserLogout => BaseUrl + "/user/logout";
        public static string UserCreateWithList => BaseUrl + "/user/createWithList";
        public static string UserCreateWithArray => BaseUrl + "/user/createWithArray";
        public static string UserGet(string userName) => BaseUrl + "/user/" + userName;
        public static string UserDelete(string userName) => BaseUrl + "/user/" + userName;
        public static string UserUpdate(string userName) => BaseUrl + "/user/" + userName;
        public static string StoreAddOrder => BaseUrl + "/store/order";
        public static string StoreFindOrder(ulong orderId) => BaseUrl + $"/store/order/{orderId}";
        public static string StoreDeleteOrder(ulong orderId) => BaseUrl + $"/store/order/{orderId}";
        public static string StoreInventory => BaseUrl + "/store/inventory";
        public static string Pet => BaseUrl + "/pet";
        public static string PetImage(long petId) => BaseUrl + $"/pet/{petId}/uploadImage";
        public static string PetFindByStatus => BaseUrl + "/pet/findByStatus";
        public static string PetById(long petId) => BaseUrl + $"/pet/{petId}";
    }
}