using System.Net;
using PetShopQa.Clients;
using PetShopQa.Enums;
using PetShopQa.Extensions;
using PetShopQa.Messages;
using PetShopQa.Models;
using Shouldly;
using Xunit;

namespace PetShopQa.Tests.XUnitTests
{
    public class StoreTests(Setup setup) : BaseXUnitTest(setup)
    {
        [Fact]
        public async Task AddOrder()
        {
            var orderResponse = await StoreClient.AddOrder(Order.Create());

            orderResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task FindOrderById()
        {
            var order = Order.Create(1, 1, 1, DateTime.Today, OrderStatus.Placed, true);
            await StoreClient.AddOrder(order).Result.IsRestResponseSuccessful();
            
            var orderResponse = await StoreClient.FindOrder(order.Id);
            
            orderResponse.Status.ShouldBe(order.Status, AssertMsg.ParameterIsWrong("Order"));
        }
        
        [Fact]
        public async Task DeleteOrderById()
        {
            var order = Order.Create(2, 2, 5, DateTime.Today, OrderStatus.Approved, false);
            await StoreClient.AddOrder(order).Result.IsRestResponseSuccessful();
            
            var orderResponse = await StoreClient.DeleteOrder(order.Id);
            
            orderResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
        
        [Fact]
        public async Task Inventory()
        {
            var order = Order.Create(3, 1, 4, DateTime.Today, OrderStatus.Approved, false);
            await StoreClient.AddOrder(order).Result.IsRestResponseSuccessful();
            
            var orderResponse = await StoreClient.Inventory();
            
            orderResponse.StatusCode.ShouldBe(HttpStatusCode.OK, AssertMsg.ResponseIsSuccessful());
        }
    }
}