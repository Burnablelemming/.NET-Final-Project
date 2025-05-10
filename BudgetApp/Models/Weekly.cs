using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    class Weekly : Income
    {
        public Weekly(string name, double amount) : base(name, amount)
        {

        }

        public override double CalculateMonthlyIncome()
        {
            return Amount * 52 / 12;
        }
    }
}
