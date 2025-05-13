using BudgetApp.Enums;
using BudgetApp.Models;
using BudgetApp.Models.Accounts;
using BudgetApp.Models.Incomes;
using BudgetApp.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Converters;

namespace BudgetApp.Controllers
{
    /// <summary>
    /// Main controller for managing the main application logic.
    /// Handles adding, removing, and updating Contributors, Expenses, Incomes, and Accounts.
    /// </summary>
    class MainWindowController
    {
        private MainWindow _view;

        // Observable collections for data binding
        private ObservableCollection<Contributor> _contributors = new ObservableCollection<Contributor>();
        private ObservableCollection<Expense> _expenses = new ObservableCollection<Expense>();
        private ObservableCollection<Income> _incomes = new ObservableCollection<Income>();
        private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();

        /// <summary>
        /// Initializes the main window controller and binds the observable collections to the view.
        /// </summary>
        public MainWindowController(MainWindow view)
        {
            _view = view;

            _view.ContributorsListBox.ItemsSource = _contributors;
            _view.ExpensesListBox.ItemsSource = _expenses;
            _view.IncomeListBox.ItemsSource = _incomes;
            _view.AccountsListBox.ItemsSource = _accounts;
        }

        /// <summary>
        /// Adds a new contributor to the Contributors list.
        /// </summary>
        public void AddContributor()
        {
            var dialog = new AddContributorDialog();

            // Open dialog and wait for validation from other Controller
            if (dialog.ShowDialog() == true)
            {
                string name = dialog.ContributorNameTextBox.Text;
                double percentageContribution = double.Parse(dialog.ContributorPercentageContributionTextBox.Text);
                Contributor c = new Contributor(name, percentageContribution);
                _contributors.Add(c);        
            }
        }

        /// <summary>
        /// Removes the selected contributor from the Contributors list.
        /// </summary>
        public void RemoveContributor()
        {
            if (_view.ContributorsListBox.SelectedItem != null)
            {
                Contributor contributor = _view.ContributorsListBox.SelectedItem as Contributor;
                _contributors.Remove(contributor);
                UpdateTotals();
            }
        }

        /// <summary>
        /// Adds a new expense to the Expenses list.
        /// </summary>
        public void AddExpense()
        {
            var dialog = new AddExpenseDialog();

            // Open dialog and wait for validation from other Controller
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
                UpdateExpenseTotal();
                // Bills contribution based on Expenses total so only call Update here.
                UpdateBillsContribution();
            }
        }

        /// <summary>
        /// Removes the selected expense from the Expenses list.
        /// </summary>
        public void RemoveExpense()
        {
            if (_view.ExpensesListBox.SelectedItem != null)
            {
                Expense expense = _view.ExpensesListBox.SelectedItem as Expense;
                _expenses.Remove(expense);
                UpdateTotals();
            }
        }

        /// <summary>
        /// Adds a new income to the Income list and the Income list inside the selected contributor.
        /// Incomes are stored inside a selected contributor, and stored in the MainWindow list for easier viewing.
        /// Allows for future implementation to include sorting Income list by contributor in the MainWindow.
        /// </summary>
        public void AddIncome()
        {
            var dialog = new AddIncomeDialog();
            Contributor selectedContributor = _view.ContributorsListBox.SelectedItem as Contributor;
            
            // Check for contributor before trying to add an income
            if (selectedContributor != null)
            {
                // Open dialog and wait for validation from other Controller
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
                            income = new WeeklyIncome(incomeName, incomeAmount);
                            break;
                        case "bi-weekly":
                            income = new BiWeeklyIncome(incomeName, incomeAmount);
                            break;
                        case "monthly":
                            income = new MonthlyIncome(incomeName, incomeAmount);
                            break;
                    }

                    selectedContributor.Income.Add(income);
                    _incomes.Add(income);
                    UpdateIncomeTotal();
                    UpdateBillsContribution();

                }

            }

            else
            {
                MessageBox.Show("Please select a contributor to add income to.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Removes the selected income from the Income list and the Income list within the contributor that holds the selected income.
        /// </summary>
        public void RemoveIncome()
        {
            if (_view.IncomeListBox.SelectedItem != null)
            {
                Income income = _view.IncomeListBox.SelectedItem as Income;

                // Check for income in Contributors list, because two lists are being managed.
                foreach (Contributor c in _contributors)
                {
                    if (c.Income.Contains(income))
                    {
                        // Remove from contributor's income list
                        c.Income.Remove(income);
                    }
                }

                // Remove from MainWindow's list
                _incomes.Remove(income);
                UpdateTotals();
            }
        }

        /// <summary>
        /// Adds a new account to the Account list.
        /// </summary>
        public void AddAccount()
        {
            var dialog = new AddAccountDialog();

            // Open dialog and wait for validation from other Controller
            if (dialog.ShowDialog() == true)
            {
                Account account = null;

                string accountName = dialog.AccountNameTextBox.Text;
                double accountAmount = double.Parse(dialog.AccountAmountTextBox.Text);
                ComboBoxItem item = dialog.AccountTypeComboBox.SelectedItem as ComboBoxItem;
                string accountType = item.Content.ToString();

                switch (accountType.ToLower()) 
                {
                    case "checking":
                        account = new CheckingAccount(accountName, accountAmount);
                        break;
                    case "savings":
                        account = new SavingsAccount(accountName, accountAmount);
                        break;
                    default:
                        Debug.WriteLine("Account Not created");
                        break;
                }

                _accounts.Add(account);
                UpdateAccountTotal();

            }
        }

        /// <summary>
        /// Removes the selected account from the Account list.
        /// </summary>
        public void RemoveAccount()
        {
            if (_view.AccountsListBox.SelectedItem != null)
            {
                Account account = _view.AccountsListBox.SelectedItem as Account;
                _accounts.Remove(account);
                UpdateTotals();
            }
        }

        /// <summary>
        /// Debugging function used to print out an Observable Collection in a readable format
        /// </summary>
        /// <typeparam name="T"> Select the type using generics </typeparam>
        /// <param name="collection"> The observable collection being printed </param>
        /// <param name="title"> The title of the observable collection being printed </param>
        public void PrintCollection<T>(ObservableCollection<T> collection, string title = "Collection Contents")
        {
            Debug.WriteLine($"\n=== {title} ===");
            foreach (var item in collection)
            {
                Debug.WriteLine(item.ToString());
            }
            Debug.WriteLine("====================\n");
        }

        /// <summary>
        /// Updates the total income display.
        /// </summary>
        private void UpdateIncomeTotal()
        {
            double sum = 0;

            foreach (var income in _incomes)
            {
                sum += income.CalculateMonthlyIncome();
            }

            _view.TotalIncomeTextBox.Text = sum.ToString("C");
        }

        /// <summary>
        /// Updates the total expense display.
        /// </summary>
        private void UpdateExpenseTotal()
        {
            double sum = 0;

            foreach (var expense in _expenses)
            {
                sum += expense.Amount;
            }

            _view.TotalExpensesTextBox.Text = sum.ToString("C");
        }

        /// <summary>
        /// Updates the total account balance display.
        /// </summary>
        private void UpdateAccountTotal()
        {
            double sum = 0;

            foreach (var account in _accounts)
            {
                sum += account.Amount;
            }

            _view.AccountTotalTextBox.Text = sum.ToString("C");
        }

        /// <summary>
        /// Calculates the bills contribution amount then updates the Bills Contribution List display.
        /// </summary>
        private void UpdateBillsContribution()
        {

            if (_contributors.Count > 0 && _incomes.Count > 0 && _expenses.Count > 0)
            {
                // Bind the Contributors to the Bills list box once everylist has an item.
                _view.BillsContributionListBox.ItemsSource = _contributors;
                double totalExpense = 0;
                double contributions = 0;
                double expensePercent = 0;

                foreach (var expense in _expenses)
                {
                    totalExpense += expense.Amount;
                }

                if (totalExpense > 0)
                {
                    foreach (var contributor in _contributors)
                    {
                        // Only calculate if contributor has income
                        if (contributor.Income.Count != 0)
                        {
                            switch (contributor.Income.First().Type)
                            {
                                case IncomeType.Weekly:
                                    expensePercent = totalExpense * (contributor.PercentageContribution / 100);
                                    contributions = expensePercent / 4; // Weeks in a month
                                    break;
                                case IncomeType.BiWeekly:
                                    expensePercent = totalExpense * (contributor.PercentageContribution / 100);
                                    contributions = expensePercent / 2; // BiWeekly, (2 weeks per month)
                                    break;
                                case IncomeType.Monthly:
                                    expensePercent = totalExpense * (contributor.PercentageContribution / 100);
                                    contributions = expensePercent;
                                    break;
                            }

                            contributor.TotalContribution = contributions;
                            Debug.WriteLine(contributor.TotalContribution);
                        }
                        else
                        {
                            // Contributor has no income
                            contributor.TotalContribution = 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates all totals (Income, Expense, Account, and Bills).
        /// </summary>
        public void UpdateTotals()
        {
            UpdateIncomeTotal();
            UpdateExpenseTotal();
            UpdateAccountTotal();
            UpdateBillsContribution();
        }
    }
}
