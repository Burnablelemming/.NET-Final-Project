using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Enums
{
    /// <summary>
    /// Represents the different types of income available in the BudgetApp.
    /// </summary>
    public enum IncomeType
    {
        /// <summary>
        /// Income that is recieved weekly.
        /// </summary>
        Weekly,

        /// <summary>
        /// Income that is recieved bi-weekly.
        /// </summary>
        BiWeekly,

        /// <summary>
        /// Income that is recieved monthly.
        /// </summary>
        Monthly,

        /// <summary>
        /// Catch case for income that may be created incorrectly.
        /// </summary>
        None
    }
}
