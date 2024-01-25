using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Core.Enteties;

namespace Solid.Core.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer GetByTz(string tz);
        Customer AddCustomer(Customer user);

        Customer UpdateCustomer(int id, Customer user);

        void DeleteCustomer(int id);
    }
}
