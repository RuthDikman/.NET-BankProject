using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Enteties;

namespace Solid.Core.Repositories
{
    public interface ICustomerRepositories
    {
        Task<List<Customer>>  GetCustomersAsync();

        Task<Customer> GetByTzAsync(string tz);

       Task<Customer> AddCustomerAsync(Customer cust);

       Task<Customer> UpdateCustomerAsync(int id, Customer cust);

        Task DeleteCustomerAsync(int id);
    }
}
