using BudgetApp.Controllers;
using BudgetApp.Interfaces;
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
    public partial class AddContributorDialog : Window, IDialogValidator
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
            if (ValidateDialog())
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void CancelContributorDialogButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
            ClearDialog();
        }

        private void ClearDialog()
        {
            this.ContributorNameTextBox.Text = string.Empty;
            this.ContributorPercentageContributionTextBox.Text = string.Empty;
        }

        public bool ValidateDialog()
        {
            return _controller.ValidateDialog();
        }
    }
}
