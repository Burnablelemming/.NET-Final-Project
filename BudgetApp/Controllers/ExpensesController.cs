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
    // Validates inputs and returns true or false 
    class ExpensesController : IDialogValidator
    {
        private AddExpenseDialog _view;

        public ExpensesController(AddExpenseDialog view)
        {
            _view = view;
        }

        public bool ValidateDialog()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_view.ExpenseNameTextBox.Text))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }

                double expenseAmount = double.Parse(_view.ExpenseAmountTextBox.Text);

                if (expenseAmount <= 0)
                {
                    throw new ArgumentException("Expense Amount cannot be negative.");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a valid expense amount.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
