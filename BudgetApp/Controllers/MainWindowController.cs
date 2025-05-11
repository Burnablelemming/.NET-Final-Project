using BudgetApp.Models;
using BudgetApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Controllers
{
    class MainWindowController
    {
        private ContributorController _contributorController;
        private ExpensesController _expensesController;
        private AccountController _accountController;
        private MainWindow _view;

        private ObservableCollection<Contributor> _contributors = new ObservableCollection<Contributor>();
        private ObservableCollection<Expense> _expenses;
        //private ObservableCollection<Account> accounts;

        public MainWindowController(MainWindow view)
        {
            _view = view;

            _view.ContributorsListBox.ItemsSource = _contributors;
            _view.ExpensesListBox.ItemsSource = _expenses;
            //_contributorController = new ContributorController(_view.ContributorsListBox);
            //_expensesController = new ExpensesController();
            //_accountController = new AccountController();

        }

        public void AddContributor()
        {
            var dialog = new AddContributorDialog();
            //_contributorController = new ContributorController(dialog);
            dialog.ShowDialog();

            if (dialog.IsValid)
            {
                //dialog.Close();
                try
                {
                    string name = dialog.ContributorNameTextBox.Text;
                    double percentageContribution = double.Parse(dialog.ContributorPercentageContributionTextBox.Text) / 100;
                    Debug.WriteLine($"{name}, {percentageContribution}");
                    Contributor c = new Contributor(name, percentageContribution);
                    _contributors.Add(c);
                    dialog.Close();
                }
                catch (FormatException ex)
                {
                    Debug.WriteLine($"PercentageContribution : {dialog.ContributorPercentageContributionTextBox.Text}");
                }
                
            }
            //_contributors.Add(_contributorController.CreateContributor());

        }
    }
}
