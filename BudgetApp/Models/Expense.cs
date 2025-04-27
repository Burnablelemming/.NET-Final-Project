using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Models
{
    internal class Expense
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public Expense()
        {
            Name = string.Empty;
            Amount = 0;
        }
    }
}
