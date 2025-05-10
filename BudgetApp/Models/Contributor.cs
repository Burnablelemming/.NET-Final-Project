using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BudgetApp.Models
{
    internal class Contributor
    {
        private string _name;
        private double _percentageContribution;
        //private int PercentageContribution { get; set; }
        public string Name
        {
            get => _name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                _name = value;
            }
        }

        public double PercentageContribution
        {
            get => _percentageContribution;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Contribution must be between 0 - 100.");
                }
                _percentageContribution = value;
            }
        }

        private ObservableCollection<Income> Income { get; set; }

        public Contributor(string name) 
        { 
            Name = name;
            Income = new ObservableCollection<Income>();
        }

        public Contributor() { }

    }
}
