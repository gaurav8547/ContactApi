using ContactApi.Models;
using ContactApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ContactApi.Repository.Class
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        ContactApiContext context;

        public CustomerRepository(ContactApiContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Customer>> All()
        {
            try
            {
                var customers = await context.Customers.ToListAsync();
                return customers;
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> Find(long id)
        {
            return await context.Customers.FindAsync(id);
        }

        public bool Remove(long id)
        {
            bool removed = false;
            var customer = this.Find(id);
            if (customer != null)
            {
                var result = Task.Run(async () => await customer).Result;
                context.Customers.Remove(result);
                context.SaveChanges();
                removed = true;
            }

            return removed;
        }

        public async Task<int> Save(Customer customer)
        {
            if(customer.Id == 0)
            {
                //Save
                SaveCustomer(customer);
            }
            else
            {
                //update
                UpdateCustomer(customer);
            }
            return await context.SaveChangesAsync();
        }

        private void UpdateCustomer(Customer customer)
        {
            try
            {
                var _customer = Task.Run(async() => await Find(customer.Id)).Result;
                _customer.FirstName = customer.FirstName ?? _customer.FirstName;
                _customer.LastName = customer.LastName ?? _customer.LastName;
                _customer.Email = customer.Email ?? _customer.Email;
                _customer.BirthDay = customer.BirthDay ?? _customer.BirthDay;

                context.Entry<Customer>(_customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void SaveCustomer(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
                context.Dispose();
        }
    }
}