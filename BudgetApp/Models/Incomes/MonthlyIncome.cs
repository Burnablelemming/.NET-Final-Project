using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models.Incomes
{
    /// <inheritdoc />
    class MonthlyIncome : Income
    {
        /// <inheritdoc />
        public MonthlyIncome(string name, double amount) : base(name, amount, IncomeType.Monthly)
        {

        }

        /// <inheritdoc />
        public override double CalculateMonthlyIncome()
        {
            return Amount;
        }
    }
}
