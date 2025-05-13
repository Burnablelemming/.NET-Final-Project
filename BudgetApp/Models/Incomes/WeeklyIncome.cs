using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models.Incomes
{
    /// <inheritdoc />
    class WeeklyIncome : Income
    {
        /// <inheritdoc />
        public WeeklyIncome(string name, double amount) : base(name, amount, IncomeType.Weekly)
        {

        }

        /// <inheritdoc />
        public override double CalculateMonthlyIncome()
        {
            // 52 weeks in a year / 12 months = average number of weeks in a month.
            return Amount * 52 / 12;
        }
    }
}
