using BudgetApp.Interfaces;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.Controllers
{
    /// <summary>
    /// Controller for validating inputs in the Add Income dialog.
    /// </summary>
    internal class IncomeController : IDialogValidator
    {
        // Give the controller access to the dialog
        private AddIncomeDialog _view;

        public IncomeController(AddIncomeDialog view)
        {
            _view = view;
        }

        /// <inheritdoc />
        public bool ValidateDialog()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.IncomeNameTextBox.Text))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }

                double incomeAmount = double.Parse(_view.IncomeAmountTextBox.Text);

                if (incomeAmount <= 0)
                {
                    throw new ArgumentException("Income Amount cannot be negative.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a valid income amount.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                Debug.WriteLine(ex.StackTrace);
                return false;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }
    }
}
