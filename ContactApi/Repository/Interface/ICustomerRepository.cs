﻿using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> All();

        Task<int> Save(Customer customer);

        Task<Customer> Find(long id);

        bool Remove(long id);
    }
}
