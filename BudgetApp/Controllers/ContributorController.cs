using BudgetApp.Models;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BudgetApp.Controllers
{
    class ContributorController
    {
        //private ObservableCollection<Contributor> _contributors = new ObservableCollection<Contributor>();
       // private ListBox _contributorsListBox;
        private AddContributorDialog _view;
        //private AddContributorDialog _view = new AddContributorDialog();

        public ContributorController(AddContributorDialog view)
        {
            _view = view;
        }

        // Creates a Contributor based on the Dialog view added
        public void validateDialog()
        {
            //Contributor c = new Contributor();
            try
            {
                if (string.IsNullOrWhiteSpace(_view.ContributorNameTextBox.Text))
                {
                    throw new ArgumentException("Name cannot be blank.");
                }
                double percentageContribution = double.Parse(_view.ContributorPercentageContributionTextBox.Text);

                if (percentageContribution <= 0 || percentageContribution > 100)
                {
                    throw new ArgumentException("Percentage must be between 1 - 100");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Enter a valid percentage.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                _view.IsValid = false;
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                _view.IsValid = false;
                return;
            }

            _view.IsValid = true;
            _view.Close();
        }

    }
}
