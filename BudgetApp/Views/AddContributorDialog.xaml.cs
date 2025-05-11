using BudgetApp.Controllers;
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
using System.Windows.Shapes;

namespace BudgetApp.Views
{
    /// <summary>
    /// Interaction logic for AddContributorDialog.xaml
    /// </summary>
    public partial class AddContributorDialog : Window
    {
        private ContributorController _controller;
        public bool IsValid = false;
        public AddContributorDialog()
        {
            InitializeComponent();
            _controller = new ContributorController(this);
        }

        private void AddContributorDialogButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if all fields for contributor are valid
            _controller.validateDialog();
        }

        private void CancelContributorDialogButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ClearAllTextFields();
        }

        private void ClearAllTextFields()
        {
            this.ContributorNameTextBox.Text = string.Empty;
            this.ContributorPercentageContributionTextBox.Text = string.Empty;
        }
    }
}
