using BudgetApp.Interfaces;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.Controllers
{
    /// <summary>
    /// Controller for validating inputs in the Add Account dialog.
    /// </summary>
    class AccountController : IDialogValidator
    {
        // Give controller access to the dialog
        private AddAccountDialog _view;

        public AccountController(AddAccountDialog view)
        {
            _view = view;
        }

        /// <inheritdoc />
        public bool ValidateDialog()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.AccountNameTextBox.Text))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }

                double incomeAmount = double.Parse(_view.AccountAmountTextBox.Text);

                if (incomeAmount <= 0)
                {
                    throw new ArgumentException("Account Amount cannot be negative.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a valid account amount.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
