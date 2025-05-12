using BudgetApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    class BiWeekly : Income
    {
        public BiWeekly(string name, double amount) : base(name, amount, IncomeType.BiWeekly)
        {

        }

        public override double CalculateMonthlyIncome()
        {
            return Amount * 26 / 12;
        }
    }
}
