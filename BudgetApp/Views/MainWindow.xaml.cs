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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// The main entry point for the BudgetApp, providing access to all major functions.
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowController _controller;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// Sets up the MainWindowController and initializes the dialog components.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _controller = new MainWindowController(this);
        }

        /// <summary>
        /// Event handler for the Add Contributor button.
        /// Calls the AddContributor method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddContributorButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddContributor();
        }

        /// <summary>
        /// Event handler for the Remove Contributor button.
        /// Calls the RemoveContributor method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void RemoveContributorButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.RemoveContributor();
        }

        /// <summary>
        /// Event handler for the Add Expense button.
        /// Calls the AddExpense method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddExpense();
        }

        /// <summary>
        /// Event handler for the Remove Expense button.
        /// Calls the RemoveExpense method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void RemoveExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.RemoveExpense();
        }

        /// <summary>
        /// Event handler for the Add Income button.
        /// Calls the AddIncome method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddIncomeButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddIncome();
        }

        /// <summary>
        /// Event handler for the Remove Income button.
        /// Calls the RemoveIncome method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void RemoveIncomeButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.RemoveIncome();
        }

        /// <summary>
        /// Event handler for the Add Account button.
        /// Calls the AddAccount method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddAccount();
        }

        /// <summary>
        /// Event handler for the Remove Account button.
        /// Calls the RemoveAccount method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void RemoveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.RemoveAccount();
        }

        /// <summary>
        /// Event handler for the Load Budget button.
        /// Calls the LoadBudget method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void LoadBudgetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the Save Budget button.
        /// Calls the SaveBudget method in the MainWindowController.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void SaveBudgetButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}