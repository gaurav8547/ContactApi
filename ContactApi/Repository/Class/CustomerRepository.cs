using ContactApi.Models;
using ContactApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactApi.Repository.Class
{
    public class CustomerRepository : ICustomerRepository
    {
        ContactApiContext context;

        public CustomerRepository(ContactApiContext _context)
        {
            this.context = _context;
        }

        public List<Customer> All()
        {
            try
            {
                return context.Customers.ToList();
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

        public Customer Find(long id)
        {
            return context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Remove(long id)
        {
            bool removed = false;
            var customer = this.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                removed = true;
            }

            return removed;
        }

        public int Save(Customer customer)
        {
            int saved = 0;
            if(customer.Id == 0)
            {
                //Save
                saved = SaveCustomer(customer);
            }
            else
            {
                //update
                saved = UpdateCustomer(customer);
            }
            return saved;
        }

        private int UpdateCustomer(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                context.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return context.SaveChanges();
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

        private int SaveCustomer(Customer customer)
        {
            try
            {
                context.Customers.Add(customer);
                return context.SaveChanges();
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
    }
}