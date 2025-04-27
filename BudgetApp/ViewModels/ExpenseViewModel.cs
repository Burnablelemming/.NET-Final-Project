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
    internal class ExpenseViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Expense> _expenses;
        public ObservableCollection<Expense> Expenses
        {
            get
            {
                Debug.WriteLine($"Expenses - get");
                return _expenses;
            }
            set
            {
                if (_expenses != value)
                {
                    _expenses = value;
                    Debug.WriteLine($"Expenses - set to {value}");
                    OnPropertyChanged(nameof(Expenses));
                }
            }
        }

        public ExpenseViewModel()
        {
            Expenses = new ObservableCollection<Expense>
            {
                new Expense { Name = "Coffee", Amount = 4.99 },
                new Expense { Name = "Groceries", Amount = 76.43 },
                new Expense { Name = "Internet Bill", Amount = 59.99 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine($"OnPropertyChanged {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
