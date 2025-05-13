using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    /// <summary>
    /// Represents an expense in the BudgetApp.
    /// An expense has a name, amount, and type (e.g., loans, groceries, fast food).
    /// </summary>
    internal class Expense
    {
        private string _name;
        private double _amount;
        private ExpenseType _type;

        /// <summary>
        /// Gets or sets the name of the expense.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the name is null, empty, or whitespace. </exception>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Expense name cannot be empty.");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the amount of the expense.
        /// Must be a non-negative value.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the amount is negative. </exception>
        public double Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Expense amount cannot be negative.");
                }
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the expense.
        /// </summary>
        public ExpenseType Type
        {
            get => _type;
            set => _type = value;
        }

        /// <summary>
        /// Initializes a new instance of the Expense class with the specified name, amount, and type.
        /// </summary>
        /// <param name="name"> The name of the expense. </param>
        /// <param name="amount"> The amount of the expense. </param>
        /// <param name="type"> The type of the expense (e.g., Loans, Groceries, Fast_Food, Insurance, Other). </param>
        public Expense(string name, double amount, ExpenseType type)
        {
            Name = name;
            Amount = amount;
            Type = type;
        }
    }
}
