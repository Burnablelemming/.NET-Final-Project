using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.ViewModels
{
    class IncomeViewModel
    {
        // Member Properties
        private ObservableCollection<Income> incomes;
        public ReadOnlyObservableCollection<Income> Incomes { get; }

        // Constructor
        public IncomeViewModel()
        {
            // TODO - Remove this for production
            // Fill the private array with default values
            incomes = [new Income("Oneish", 99.0), new Income("Two", 102.23), new Income("Three", 146.22)];

            // This is a wrapper not a new, independant collection. It responds to write-updates.
            Incomes = new ReadOnlyObservableCollection<Income>(incomes);
        }
    }
}
