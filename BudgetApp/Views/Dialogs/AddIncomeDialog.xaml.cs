﻿using BudgetApp.Controllers;
using BudgetApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetApp.Views
{
    /// <summary>
    /// Interaction logic for AddIncomeDialog.xaml
    /// Provides a dialog window for adding a new income.
    /// Implements the IDialogValidator interface for input validation.
    /// </summary>
    public partial class AddIncomeDialog : Window, IDialogValidator
    {
        private IncomeController _controller;

        /// <summary>
        /// Initializes a new instance of the AddIncomeDialog class.
        /// Sets up the IncomeController and initializes the dialog components.
        /// </summary>
        public AddIncomeDialog()
        {
            InitializeComponent();
            _controller = new IncomeController(this);
        }

        /// <summary>
        /// Event handler for the Add button.
        /// Validates the dialog inputs and closes the dialog and sets the DialogResult to true if valid.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddIncomeDialogButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateDialog())
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        /// <summary>
        /// Event handler for the Cancel button.
        /// Closes the dialog without saving and clears the input fields and sets the DialogResult to false.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void CancelIncomeDialogButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
            ClearDialog();
        }

        /// <summary>
        /// Clears all input fields in the dialog.
        /// Resets the combo box to it's default state.
        /// </summary>
        public void ClearDialog()
        {
            this.IncomeNameTextBox.Text = string.Empty;
            this.IncomeAmountTextBox.Text = string.Empty;
            this.IncomeTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Validates the dialog input using the associated AccountController.
        /// </summary>
        /// <returns> True if the dialog inputs are valid, false otherwise. </returns>
        public bool ValidateDialog()
        {
            return _controller.ValidateDialog();
        }
    }
}
