using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BudgetApp.Models
{
    internal class Contributor
    {
        public string Name { get; set; }
        public List<Income> Income { get; set; }

        public Contributor(string name, List<Income> income) 
        { 
            Name = name;
            Income = income;
        }

        public Contributor() { }

    }
}
