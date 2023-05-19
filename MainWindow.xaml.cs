using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.View;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            window.Content = new CustomerView();
        }


        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            window.Content = new AddCustomerView();
        }

        private void ShowCustomers(object sender, RoutedEventArgs e)
        {
            window.Content = new CustomerView();
        }
    }
}
