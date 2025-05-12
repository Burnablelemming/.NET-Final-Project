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
    /// Interaction logic for AddExpenseDialog.xaml
    /// </summary>
    public partial class AddExpenseDialog : Window, IDialogValidator
    {
        private ExpensesController _controller;
        public AddExpenseDialog()
        {
            InitializeComponent();
            _controller = new ExpensesController(this);
        }

        private void AddExpenseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateDialog())
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void CancelExpenseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
            ClearDialog();
        }

        public void ClearDialog()
        {
            this.ExpenseNameTextBox.Text = string.Empty;
            this.ExpenseAmountTextBox.Text = string.Empty;
            this.ExpenseTypeComboBox.SelectedIndex = 0;
        }

        public bool ValidateDialog()
        {
            return _controller.ValidateDialog();
        }
    }
}
