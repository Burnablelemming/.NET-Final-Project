using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BudgetApp.Models
{
    internal abstract class Income
    {
        private string _name;
        private double _amount;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or whitespace.");
                }
                _name = value;
            }
        }

        public double Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative.");
                }
                _amount = value;
            }
        }

        public Income(string name, double amount) 
        {
            Name = name;
            Amount = amount;
        }

        public abstract double CalculateMonthlyIncome();
    }
}
