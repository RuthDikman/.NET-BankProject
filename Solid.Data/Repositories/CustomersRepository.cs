using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solid.Core.Enteties;
using Solid.Core.Repositories;

namespace Solid.Data.Repositories
{
    public class CustomersRepository:ICustomerRepositories
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }
        public Customer AddCustomer(Customer cust)
        {
            _context.Customers.Add(cust);
            _context.SaveChanges();
            return cust;
        }

        public void DeleteCustomer(int id)
        {
            var temp = _context.Customers.Find(id);
            _context.Customers.Remove(temp);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(u => u.TurnsList).ToList();
        }

        public Customer GetByTz(string tz)
        {
            return _context.Customers.Include(u => u.TurnsList).ToList().Find(u => u.Tz == tz);
        }

        public Customer UpdateCustomer(int id, Customer cust)
        {
            var temp = _context.Customers.Find(id);
            if(temp != null)
            {
               temp.Id = cust.Id;
                temp.Name= cust.Name;
                temp.Tz = cust.Tz;
            }
            _context.SaveChanges();
            return temp;
        }
    }
}
