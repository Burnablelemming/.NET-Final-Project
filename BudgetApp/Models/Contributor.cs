using BudgetApp.Models.Incomes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BudgetApp.Models
{
    /// <summary>
    /// Represents a contributor in the BudgetApp.
    /// A contributor has a name, a percentage contribution, a total contribution, and a collection of incomes.
    /// </summary>
    internal class Contributor : INotifyPropertyChanged
    {
        private string _name;
        private double _percentageContribution;
        private double _totalContribution;

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Gets or sets the name of the contributor
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the name is null, empty, or whitespace. </exception>
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
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Gets or sets the percentage contribution of the contributor
        /// Must be between 0 and 100.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the value is not between 0 or 100. </exception>
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
                OnPropertyChanged(nameof(PercentageContribution));
            }
        }

        /// <summary>
        /// Gets or sets the total contribution of the contributor
        /// Must be positive.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown if the value is less than 0. </exception>
        public double TotalContribution
        {
            get => _totalContribution;
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Total contribution cannot be negative.");
                }
                _totalContribution = value;
                OnPropertyChanged(nameof(TotalContribution));
            }
        }

        /// <summary>
        /// Gets the collection of incomes associated with the contributor.
        /// </summary>
        public ObservableCollection<Income> Income { get; set; }

        /// <summary>
        /// Initializes a new instance of the Contributor class with the specified name and percentage contribution.
        /// </summary>
        /// <param name="name"> The name of the contributor. </param>
        /// <param name="percentageContribution"> The percentage contribution of the contributor. </param>
        public Contributor(string name, double percentageContribution) 
        { 
            Name = name;
            PercentageContribution = percentageContribution;
            Income = new ObservableCollection<Income>();
        }

        /// <summary>
        /// Initializes a new instance of the Contributor class with default values.
        /// </summary>
        public Contributor() 
        {
            Income = new ObservableCollection<Income>();
        }

        /// <summary>
        /// Notifies the UI that a property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
