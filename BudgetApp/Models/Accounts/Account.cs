using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Navigation;

namespace BudgetApp.Models.Accounts
{
    /// <summary>
    /// Represents a financial account in the BudgetApp.
    /// This is an abstract base calss for all account types.
    /// </summary>
    internal abstract class Account
    {
        private string _name;
        private double _amount;
        private AccountType _type;

        /// <summary>
        /// Gets or sets the name of the account.
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
        /// Gets or sets the amount of the account.
        /// Must be positive.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the valud is negative. </exception>
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
        /// Gets the type of Account (e.g., Checking, Savings, None).
        /// This property is set in the constructor and is read-only outside the class.
        /// </summary>
        public AccountType Type
        {
            get => _type;
            private set
            {
                _type = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Account class with the specified name, amount, and type.
        /// </summary>
        /// <param name="name"> The account name. </param>
        /// <param name="amount"> The initial ammount of the account. </param>
        /// <param name="type"> The type of the account (e.g., Checking, Savings, None). </param>
        public Account(string name, double amount, AccountType type)
        {
            Name = name;
            Amount = amount;
            Type = type;
        }

        /// <summary>
        /// Returns a string representation of the account.
        /// </summary>
        /// <returns> A formatted string representing the account. </returns>
        public override string ToString()
        {
            return $"Account\nName: {Name}, Amount: {Amount}, Type: {Type}";
        }
    }
}
