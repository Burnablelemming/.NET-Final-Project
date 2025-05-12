using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    class Monthly : Income
    {
        public Monthly(string name, double amount) : base(name, amount, IncomeType.Monthly)
        {

        }

        public override double CalculateMonthlyIncome()
        {
            return Amount;
        }
    }
}
