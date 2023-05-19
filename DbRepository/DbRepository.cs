using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp2.Interfaces;
using WpfApp2.Model;

namespace WpfApp2.DbRepository
{
    public class DbRepository : IDbRepository
    {
        public List<Customer> FetchData()
        {
            using (CustomerContext db = new CustomerContext())
            {
                return db.Customers.ToList();
            }
        }

        public void AddData(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public void UpdateDate(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                var customerToUpdate = db.Customers.Find(customer.Id);
                customerToUpdate.Name = customer.Name;
                customerToUpdate.CompanyName = customer.CompanyName;
                customerToUpdate.Phone = customer.Phone;
                customerToUpdate.Email = customer.Email;
                db.SaveChanges();
            }
        }

        public void DeleteData(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        public List<Customer> FilterData(Customer customer)
        {
            using (CustomerContext db = new CustomerContext())
            {
                return db.Customers.FromSql($"getCustomers @name={customer.Name}, @companyName={customer.CompanyName}, @phone={customer.Phone}, @email={customer.Email}").ToList();
            }
        }
    }
}
