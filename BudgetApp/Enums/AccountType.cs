using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Enums
{
    /// <summary>
    /// Represents the different types of accounts available in the BudgetApp.
    /// The BudgetApp uses these for printing out each account with its specified type.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// A standard checking account, typically used for everyday transactions.
        /// </summary>
        Checking,

        /// <summary>
        /// Savings account, generally used for storing funds for future or emergency use.
        /// </summary>
        Savings,

        /// <summary>
        /// Catch case for when an account may be created incorrectly
        /// </summary>
        None
    }
}
