using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Enums
{
    /// <summary>
    /// Represents the different types of expenses available in the BudgetApp.
    /// </summary>
    public enum ExpenseType
    {
        /// <summary>
        /// Expenses related to loans. Student loans, car loans, mortgage, etc.
        /// </summary>
        Loans,

        /// <summary>
        /// Expenses related to groceries and other household essentials.
        /// </summary>
        Groceries,

        /// <summary>
        /// Expenses related to fast food.
        /// </summary>
        Fast_Food,

        /// <summary>
        /// Expenses related to insurance. Car insurance, health insurance, etc.
        /// </summary>
        Insurance,

        /// <summary>
        /// Expenses that don't specify any of these other categories.
        /// </summary>
        Other
    }
}
