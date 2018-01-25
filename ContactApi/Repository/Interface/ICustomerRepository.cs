using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Repository.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> All();

        int Save(Customer customer);

        Customer Find(long id);

        bool Remove(long id);
    }
}
