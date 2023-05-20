using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Interfaces;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    class AddCustomerViewModel : ViewModelBase, IAddCustomerViewModel
    {
        private IDbRepository _repository;

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

        public AddCustomerViewModel(IDbRepository repository)
        {
            SelectedCustomer = new Customer();
            _repository = repository;
        }

        public async Task AddCustomer()
        {
            await Task.Run(() => _repository.AddData(SelectedCustomer));
            SelectedCustomer = new Customer();
        }
    }
}
