using System.Windows;
using System.Windows.Controls;
using WpfApp2.DbRepository;
using WpfApp2.Interfaces;
using WpfApp2.ViewModel;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        private readonly ICustomerViewModel _customerViewModel;
        public CustomerView()
        {
            InitializeComponent();
            _customerViewModel = new CustomerViewModel(DbRepositorySingelton.GetInstance().GetDbRepository());
            this.DataContext = _customerViewModel;
        }


        private async void UpdateCustomer(object sender, RoutedEventArgs e)
        {
           await _customerViewModel.UpdateData();
        }

        private async void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            await _customerViewModel.DeleteData();
        }

        private async void FilterCustomers(object sender, RoutedEventArgs e)
        {
           await _customerViewModel.FetchFilteredData();
        }
    }
}
