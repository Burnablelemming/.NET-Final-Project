using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    internal class ExpenseViewModel
    {
        // Member Properties
        private ObservableCollection<Expense> expenses;
        public ReadOnlyObservableCollection<Expense> Expenses { get; }

        // Constructor
        public ExpenseViewModel()
        {
            // TODO - Remove this for production
            // Fill the private array with default values
            expenses = [new Expense("Oneish", 99.0), new Expense("Two", 102.23), new Expense("Three", 146.22)];

            // This is a wrapper not a new, independant collection. It responds to write-updates.
            Expenses = new ReadOnlyObservableCollection<Expense>(expenses);
        }

        public void AddExpense(Expense expense) => expenses.Add(expense);
        public void RemoveExpense(Expense expense) => expenses.Remove(expense);
    }
}
