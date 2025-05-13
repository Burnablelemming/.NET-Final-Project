using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models.Accounts
{
    /// <inheritdoc />
    internal class CheckingAccount : Account
    {
        /// <inheritdoc />
        public CheckingAccount(string name, double amount) : base(name, amount, AccountType.Checking)
        {

        }
    }
}
