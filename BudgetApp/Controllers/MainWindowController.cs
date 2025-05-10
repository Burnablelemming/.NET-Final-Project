using BudgetApp.Views;
using System;
using System.Collections.Generic;
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

        public MainWindowController(MainWindow view)
        {
            _view = view;

            _contributorController = new ContributorController();
            _expensesController = new ExpensesController();
            _accountController = new AccountController();

        }

    }
}
