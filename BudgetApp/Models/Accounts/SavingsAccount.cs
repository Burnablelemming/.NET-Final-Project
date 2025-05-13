using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models.Accounts
{
    /// <inheritdoc />
    internal class SavingsAccount : Account
    {
        /// <inheritdoc />
        public SavingsAccount(string name, double amount) : base(name, amount, AccountType.Savings)
        {

        }
    }
}
