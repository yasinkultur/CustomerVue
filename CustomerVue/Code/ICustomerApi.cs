using CustomerVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerVue.Code
{
    public interface ICustomerApi
    {
        Task<Customer> GetCustomerAsync(int customerId);
        Task<List<Customer>> GetCustomers();
    }
}
