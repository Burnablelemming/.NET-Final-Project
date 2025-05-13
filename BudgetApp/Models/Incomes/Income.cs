using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BudgetApp.Models.Incomes
{
    /// <summary>
    /// Represents an abstract base calss for all types of income in the BudgetApp.
    /// Provides a foundation for calculating monthly income.
    /// </summary>
    internal abstract class Income
    {
        private string _name;
        private double _amount;
        private IncomeType _type;

        /// <summary>
        /// Gets or sets the name of the income.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the name is null, empty, or whitespace. </exception>
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

        /// <summary>
        /// Gets or sets the amount of the income.
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
                    throw new ArgumentException("Amount cannot be negative.");
                }
                _amount = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of income (e.g Weekly, BiWeekly, Monthly).
        /// This property is set in the constructor and is read-only outside the class.
        /// </summary>
        public IncomeType Type
        {
            get => _type;
            private set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Income class with the specified name, amount, and type.
        /// </summary>
        /// <param name="name"> The name of the income source. </param>
        /// <param name="amount"> The amount of the income. </param>
        /// <param name="type"> The type of the income (e.g., Weekly, BiWeekly, Monthly). </param
        public Income(string name, double amount, IncomeType type)
        {
            Name = name;
            Amount = amount;
            Type = type;
        }

        /// <summary>
        /// Calculates the monthly equivalent of this income.
        /// Must be implemented by derived classes.
        /// </summary>
        /// <returns> The calculated monthly income amount. </returns>
        public abstract double CalculateMonthlyIncome();

        /// <summary>
        /// Returns a string reperesentaiont of the income.
        /// </summary>
        /// <returns> A formatted string representing the income. </returns>
        public override string ToString()
        {
            return $"Name: {Name}, Amount: {Amount}, Type: {Type}";
        }
    }
}
