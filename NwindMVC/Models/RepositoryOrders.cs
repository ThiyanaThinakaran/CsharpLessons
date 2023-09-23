using Microsoft.EntityFrameworkCore;
using NwindMVC.Models;



namespace NwindMVC.Models
{
    public class RepositoryOrders
    {
        private NorthWindContext _context;
        public RepositoryOrders(NorthWindContext context)
        {
            _context = context;
        }
        //(from o in _context.Orders select o.OrderId).ToList();
        public List<int> GetAllOrderID()
        {
            //try
            //{
                List<int> OrdersIDs = (from o in _context.Orders select o.OrderId).ToList(); //_context.Orders.Select(o => o.OrderId).ToList();
                return OrdersIDs;
           // }
           // catch (Exception ex)
           // {
                // Log the exception or handle it as needed
                // For debugging purposes, you can also throw it again here
             //   throw ex;
            //}
        }





        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }
        public Order FindOrderById(int ID)
        {
            Order order = _context.Orders.Find(ID);
            return order;
        }
        public List<Order> FindOrderByCustomerID(string customerID)
        {
            List<Order> customerorders = (from o in _context.Orders where o.CustomerId == customerID select o).ToList();
            return customerorders;
        }
        public List<OrderDetail> FindOrderDetailByOrderId(int Id)
        {
            //List<OrderDetail> orderDetails = (from od in _context.OrderDetails where od.OrderId == orderID select od).ToList();
            //Order order = _context.Orders.Find(Id);
            //return order.OrderDetails.ToList();
            List<Order> ordersWithOrderDetails = _context.Orders.Include(d => d.OrderDetails).ToList();
            Order order = ordersWithOrderDetails.FirstOrDefault(x => x.OrderId == Id);
            return order.OrderDetails.ToList();
        }
        public Product GetProductById(int productid)
        {
            Product product = (from p in _context.Products where p.ProductId == productid select p).SingleOrDefault();
            return product;
        }
    }
}