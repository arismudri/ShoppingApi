using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApi.Repository
{
    public interface InItem
    {
        List<Customer> GetCustomer(int Id);
    }

    public class ItemService : InItem
    {
        private readonly ShoppingDBContext _context;
        public ItemService(ShoppingDBContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomer(int Id)
        {
            throw new NotImplementedException();
        }
        //public List<Customer> GetCustomer(int Id)
        //{
        //    return _context.Customers.Include(c => c.Items).Where(c => c.Id == Id).ToArrayAsync();//.Find(Id);
        //    //return customer;
        //}
    }
}
