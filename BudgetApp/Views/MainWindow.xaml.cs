using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using BudgetApp.Controllers;

namespace BudgetApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContributor_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddContributorDialog();
            dialog.ShowDialog(); 
        }
    }
}