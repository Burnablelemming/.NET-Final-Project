using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BudgetApp.Models
{
    internal class Income
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        // Contributor -> prop income, Income income;
        public Income() 
        {
            Name = string.Empty;
            Amount = 0;
        }
    }
}
