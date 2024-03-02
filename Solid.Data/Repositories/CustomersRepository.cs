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
        public async Task<Customer>  AddCustomerAsync(Customer cust)
        {
            _context.Customers.Add(cust);
            await _context.SaveChangesAsync();
            return cust;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var temp = _context.Customers.Find(id);
            _context.Customers.Remove(temp);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Customer>>  GetCustomersAsync()
        {
            return _context.Customers.Include(u => u.TurnsList).ToList();
        }

        public async Task<Customer>  GetByTzAsync(string tz)
        {
            return _context.Customers.Include(u => u.TurnsList).ToList().Find(u => u.Tz == tz);
        }

        public async Task<Customer>  UpdateCustomerAsync(int id, Customer cust)
        {
            var temp = _context.Customers.Find(id);
            if(temp != null)
            {
               temp.Id = cust.Id;
                temp.Name= cust.Name;
                temp.Tz = cust.Tz;
            }
            await _context.SaveChangesAsync();
            return temp;
        }
    }
}
