﻿using ContactApi.Models;
using ContactApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.Repository.Class
{
    public class SupplierRepository : ISupplierRepository, IDisposable
    {
        ContactApiContext context;
        public SupplierRepository(ContactApiContext contactApiContext)
        {
            context = contactApiContext;
        }

        public async Task<List<Supplier>> All()
        {
            try
            {
                var customers = await context.Suppliers.ToListAsync();
                return customers;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Supplier> Find(long id)
        {
            return await context.Suppliers.FindAsync(id);
        }

        public bool Remove(long id)
        {
            bool removed = false;
            var customer = this.Find(id);
            if (customer != null)
            {
                var result = Task.Run(async () => await customer).Result;
                context.Suppliers.Remove(result);
                context.SaveChanges();
                removed = true;
            }

            return removed;
        }

        public async Task<int> Save(Supplier supplier)
        {
            if (supplier.Id == 0)
            {
                //Save
                SaveSupplier(supplier);
            }
            else
            {
                //update
                UpdateCustomer(supplier);
            }
            return await context.SaveChangesAsync();
        }

        private void UpdateCustomer(Supplier supplier)
        {
            try
            {
                var _supplier = Task.Run(async () => await Find(supplier.Id)).Result;
                _supplier.FirstName = supplier.FirstName ?? _supplier.FirstName;
                _supplier.LastName = supplier.LastName ?? _supplier.LastName;
                _supplier.Telephone = supplier.Telephone ?? _supplier.Telephone;

                context.Entry<Supplier>(_supplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
