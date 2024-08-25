using PetShopQa.Models;
using RestSharp;

namespace PetShopQa.Clients
{
    public class StoreClient : RestTestClient
    {
        public static async Task<RestResponse> AddOrder(Order order)
        {
            var url = Url.StoreAddOrder;
            return await Post(url, order);
        }
        
        public static async Task<Order> FindOrder(ulong orderId)
        {
            var url = Url.StoreFindOrder(orderId);
            return await GetSerialize<Order>(url);
        }
        
        public static async Task<RestResponse> DeleteOrder(ulong orderId)
        {
            var url = Url.StoreDeleteOrder(orderId);
            return await Delete(url);
        }
        
        public static async Task<RestResponse> Inventory()
        {
            var url = Url.StoreInventory;
            return await Get(url);
        }
    }
}