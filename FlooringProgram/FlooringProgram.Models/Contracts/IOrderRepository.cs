using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Contracts
{
    public interface IOrderRepository
    {
        List<Order> GetOrders(DateTime identifier);

        Order AddOrder(Order order, DateTime identifier);

        List<Order> EditOrder(Order order, int orderToEdit, DateTime identifier);

        bool RemoveOrder(int orderToRemove, DateTime identifier);
    }
}
