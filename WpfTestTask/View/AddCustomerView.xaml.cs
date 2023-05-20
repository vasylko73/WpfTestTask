using System.Windows;
using System.Windows.Controls;
using WpfApp2.DbRepository;
using WpfApp2.Interfaces;
using WpfApp2.ViewModel;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Page
    {
        private readonly IAddCustomerViewModel _addCustomerViewModel;

        public AddCustomerView()
        {
            InitializeComponent();
            _addCustomerViewModel = new AddCustomerViewModel(DbRepositorySingelton.GetInstance().GetDbRepository());
            this.DataContext = _addCustomerViewModel;
        }

        private async void AddCustomer(object sender, RoutedEventArgs e)
        {
           await _addCustomerViewModel.AddCustomer();
        }
    }
}
