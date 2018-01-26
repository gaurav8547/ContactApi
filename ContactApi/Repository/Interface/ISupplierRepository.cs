using ContactApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repository.Interface
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> All();

        Task<int> Save(Supplier supplier);

        Task<Supplier> Find(long id);

        bool Remove(long id);
    }
}
