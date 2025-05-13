using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models.Incomes
{
    /// <inheritdoc />
    class BiWeeklyIncome : Income
    {
        /// <inheritdoc />
        public BiWeeklyIncome(string name, double amount) : base(name, amount, IncomeType.BiWeekly)
        {

        }

        /// <inheritdoc />
        public override double CalculateMonthlyIncome()
        {
            // 52 weeks per year / 2, then by 12 for the average amount of biweekly weeks per month.
            return Amount * 26 / 12;
        }
    }
}
