using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICustomerBL
    {
        public Task<List<Customer>> getAllCustomers();
        public Task<Customer> getCustomer(int id);
        public void updateCustomer(Customer customerToUpdate);
        public Task<int> addNewCustomer(Customer customerToAdd);
        public void deleteCustomer(int id);

    }
}
