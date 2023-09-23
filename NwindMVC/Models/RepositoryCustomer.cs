using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NwindMVC.Models;

namespace NWind.Models
{
    public class RepositoryCustomer
    {
        private readonly NorthWindContext _context;
        public int SelectedId { get; set; }
        public List<SelectListItem> CustomerSelectView { get; set; }
        public RepositoryCustomer() { }
        public RepositoryCustomer(NorthWindContext context)
        {
            _context = context;
        }
        public Customer FindCustomerById(string id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }
        public List<string> GetAllCustomerId()
        {
            List<string> customerIds = new List<string>();
            foreach (var customer in _context.Customers)
            {
                customerIds.Add(customer.CustomerId);
            }
            return customerIds;
        }
        public List<Order> FindCustomerdetailbyOrders(string id)
        {
            List<Customer> customers = _context.Customers.Include(o => o.Orders).ToList();
            Customer customer = customers.FirstOrDefault(x => x.CustomerId == id);
            return customer.Orders.ToList();
        }
    }
}
