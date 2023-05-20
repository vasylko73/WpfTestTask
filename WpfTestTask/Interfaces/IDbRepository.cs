using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.Interfaces
{
    interface IDbRepository
    {
        public List<Customer> FetchData();
        public void AddData(Customer customer);
        public void UpdateDate(Customer customer);
        public void DeleteData(Customer customer);
        public List<Customer> FilterData(Customer customer);
    }
}
