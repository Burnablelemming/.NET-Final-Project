using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using BudgetApp.Controllers;

namespace BudgetApp.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowController _controller;
        public MainWindow()
        {
            InitializeComponent();
            _controller = new MainWindowController(this);
        }

        private void AddContributorButton_Click(object sender, RoutedEventArgs e)
        {
            // Possible implementation:
            // var dialog = new dialog();
            // dialog.showView;
            _controller.AddContributor();
        }

        private void RemoveContributorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveExpenseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddIncomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveIncomeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadBudgetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBudgetButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public ListBox GetContributorListBox()
        {
            return this.ContributorsListBox;
        }
    }
}