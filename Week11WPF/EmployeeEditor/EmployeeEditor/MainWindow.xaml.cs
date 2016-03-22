using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EmployeeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.viewModel;  
        }

        public class MainWindowViewModel : INotifyPropertyChanged
        {
            private Employee selectedEmployee;

            public List<Employee> Employees
            {
                get
                {
                    return AccessData.GetEmployeesWithNonNullManagerID();
                }
            }

            public Employee SelectedEmployee
            {
                get
                {
                    return selectedEmployee;
                }
                set
                {
                    selectedEmployee = value;
                    this.OnPropertyChanged("SelectedEmployee");
                }
            }

            protected virtual void OnPropertyChanged(string property)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

 

        private void employeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.viewModel.SelectedEmployee = this.employeeGrid.SelectedItem as Employee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccessData.SaveChanges();
        }
    }
}
