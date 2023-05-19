using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interfaces;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    class CustomerViewModel : ViewModelBase, ICustomerViewModel
    {
        private IDbRepository _repository;

        private List<Customer> _customers;
        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private Customer _filterCustomer;
        public Customer FilterCustomer
        {
            get { return _filterCustomer; }
            set
            {
                _filterCustomer = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel(IDbRepository repository)
        {
            FilterCustomer = new Customer();
            _repository = repository;
            Task.Run(async () => await FetchData());
        }

        public async Task FetchData()
        {
            Customers = await Task.Run(()=> _repository.FetchData());
        }

        public async Task UpdateData()
        {
            await Task.Run(()=>_repository.UpdateDate(SelectedCustomer));
            await FetchData();
        }

        public async Task DeleteData()
        {
            await Task.Run(()=>_repository.DeleteData(SelectedCustomer));
            await FetchData();
        }

        public async Task FetchFilteredData()
        {
            await Task.Run(()=>Customers = _repository.FilterData(FilterCustomer));
        }

    }
}
