using SufferShopDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SufferShopDB.Repos
{
    public interface IProductRepo
    {

        void AddNewProductToStock(int newProductId, int locationId);

        void RemoveProductAtLocation(int removedProductId, int locationId);


        Task<List<OrderLineItem>> GetOrderedProductsInAnOrderAsync(int orderId);



    }
}
