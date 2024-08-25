using PetShopQa.Models;

namespace PetShopQa.Extensions
{
    public static class OrderExtension
    {
        public static void PrintOrder(this Order newOrder)
        {
            Console.Write("\n Id = " + newOrder.Id);
            Console.Write("\n PetId = " + newOrder.PetId);
            Console.Write("\n Quantity = " + newOrder.Quantity);
            Console.Write("\n ShipDate = " + newOrder.ShipDate);
            Console.Write("\n Status = " + newOrder.Status);
            Console.Write("\n Complete = " + newOrder.Complete);
            
            //TODO: logger info - print, а до того засунуть метод ToString  в класс 
        }
    }
}