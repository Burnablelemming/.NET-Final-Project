using BudgetApp.Interfaces;
using BudgetApp.Models;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BudgetApp.Controllers
{
    class ContributorController : IDialogValidator
    {
        private AddContributorDialog _view;
        
        public ContributorController(AddContributorDialog view)
        {
            _view = view;
        }

        // Creates a Contributor based on the Dialog view added
        public bool ValidateDialog()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.ContributorNameTextBox.Text))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }
                double percentageContribution = double.Parse(_view.ContributorPercentageContributionTextBox.Text);

                if (percentageContribution <= 0 || percentageContribution > 100)
                {
                    throw new ArgumentException("Percentage must be between 1 - 100");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a valid percentage.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
