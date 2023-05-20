using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Interfaces
{
    interface ICustomerViewModel
    {
        public Task FetchData();
        public Task UpdateData();
        public Task DeleteData();
        public Task FetchFilteredData();
    }
}
