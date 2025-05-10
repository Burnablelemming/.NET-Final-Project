using BudgetApp.Models;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BudgetApp.Controllers
{
    class ContributorController
    {
        private ObservableCollection<Contributor> _contributors = new ObservableCollection<Contributor>();
        private ListBox _contributorsListBox;
        private AddContributorDialog _view = new AddContributorDialog();

        public ContributorController(ListBox contributorsList)
        {
            _contributorsListBox = contributorsList;
            _contributorsListBox.ItemsSource = _contributors;
        }

        public void AddContributor() {

            // if _view.IsValid()
            Contributor c = new Contributor();
            //c.name = _view.ContributorNameTextBox.Text;
            //contributors.add(c);
            // close dialog
        }


    }
}
