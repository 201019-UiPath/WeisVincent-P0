using SufferShopDB.Models;
using SufferShopDB.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SufferShopBL
{
    public class OrderService
    {
        readonly IOrderRepo repo;

        public OrderService(IOrderRepo repo)
        {
            this.repo = repo;
        }



        

    }
}
