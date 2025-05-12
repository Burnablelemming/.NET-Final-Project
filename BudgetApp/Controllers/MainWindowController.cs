using BudgetApp.Enums;
using BudgetApp.Models;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BudgetApp.Controllers
{
    class MainWindowController
    {
        private ContributorController _contributorController;
        private ExpensesController _expensesController;
        private AccountController _accountController;
        private MainWindow _view;

        private ObservableCollection<Contributor> _contributors = new ObservableCollection<Contributor>();
        private ObservableCollection<Expense> _expenses = new ObservableCollection<Expense>();
        private ObservableCollection<Income> _incomes = new ObservableCollection<Income>();
        //private ObservableCollection<Account> accounts;

        public MainWindowController(MainWindow view)
        {
            _view = view;

            _view.ContributorsListBox.ItemsSource = _contributors;
            _view.ExpensesListBox.ItemsSource = _expenses;
            _view.IncomeListBox.ItemsSource = _incomes;
            //_contributorController = new ContributorController(_view.ContributorsListBox);
            //_expensesController = new ExpensesController();
            //_accountController = new AccountController();

        }

        public void AddContributor()
        {
            var dialog = new AddContributorDialog();

            if (dialog.ShowDialog() == true)
            {
                string name = dialog.ContributorNameTextBox.Text;
                double percentageContribution = double.Parse(dialog.ContributorPercentageContributionTextBox.Text);
                //Debug.WriteLine($"{name}, {percentageContribution}");
                Contributor c = new Contributor(name, percentageContribution);
                _contributors.Add(c);        
            }
        }

        public void AddExpense()
        {
            var dialog = new AddExpenseDialog();

            if (dialog.ShowDialog() == true)
            {
                string expenseName = dialog.ExpenseNameTextBox.Text;
                double expenseAmount = double.Parse(dialog.ExpenseAmountTextBox.Text);

                // Treating Type.Other as the default
                ExpenseType type = ExpenseType.Other;
                ComboBoxItem item = dialog.ExpenseTypeComboBox.SelectedItem as ComboBoxItem;
                string expenseType = item.Content.ToString();

                switch (expenseType.ToLower()) 
                {
                    case "loan":
                        type = ExpenseType.Loans;
                        break;
                    case "groceries":
                        type = ExpenseType.Groceries;
                        break;
                    case "fast food":
                        type = ExpenseType.Fast_Food;
                        break;
                    case "insurance":
                        type = ExpenseType.Insurance;
                        break;
                }

                Expense expense = new Expense(expenseName, expenseAmount, type);

                _expenses.Add(expense);

                Debug.WriteLine("Dialog is valid");
            }
        }

        public void AddIncome()
        {
            var dialog = new AddIncomeDialog();
            Contributor selectedContributor = _view.ContributorsListBox.SelectedItem as Contributor;
            
            if (selectedContributor != null)
            {
                if (dialog.ShowDialog() == true)
                {
                    Income income = null;
                    ComboBoxItem item = dialog.IncomeTypeComboBox.SelectedItem as ComboBoxItem;
                    string incomeType = item.Content.ToString();

                    string incomeName = dialog.IncomeNameTextBox.Text;
                    double incomeAmount = double.Parse(dialog.IncomeAmountTextBox.Text);

                    switch (incomeType.ToLower()) 
                    {
                        case "weekly":
                            income = new Weekly(incomeName, incomeAmount);
                            break;
                        case "bi-weekly":
                            income = new BiWeekly(incomeName, incomeAmount);
                            break;
                        case "monthly":
                            income = new Monthly(incomeName, incomeAmount);
                            break;
                    }

                    selectedContributor.Income.Add(income);
                    _incomes.Add(income);
                    //PrintCollection(selectedContributor.Income, "Income List");

                }

            }

            else
            {
                MessageBox.Show("Please select a contributor to add income to.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void PrintCollection<T>(ObservableCollection<T> collection, string title = "Collection Contents")
        {
            Debug.WriteLine($"\n=== {title} ===");
            foreach (var item in collection)
            {
                Debug.WriteLine(item.ToString());
            }
            Debug.WriteLine("====================\n");
        }
    }
}
