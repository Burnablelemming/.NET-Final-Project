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
    /// Interaction logic for AddAccountDialog.xaml
    /// Provides a dialog window for adding a new account.
    /// Implements the IDialogValidator interface for input validation.
    /// </summary>
    public partial class AddAccountDialog : Window, IDialogValidator
    {
        private AccountController _controller;

        /// <summary>
        /// Initializes a new instance of the AddAccountDialog class.
        /// Sets up the AccountController and initializes the dialog components.
        /// </summary>
        public AddAccountDialog()
        {
            InitializeComponent();
            _controller = new AccountController(this);
        }

        /// <summary>
        /// Event handler for the Add button.
        /// Validates the dialog inputs and closes the dialog and sets the DialogResult to true if valid.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        private void AddAccountDialogButton_Click(object sender, RoutedEventArgs e)
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
        private void CancelAccountDialogButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult= false;
            this.Close();
            ClearDialog();

        }

        /// <summary>
        /// Clears all input fields in the dialog.
        /// Resets the combo box to it's default state.
        /// </summary>
        public void ClearDialog()
        {
            this.AccountNameTextBox.Text = string.Empty;
            this.AccountAmountTextBox.Text = string.Empty;
            this.AccountTypeComboBox.SelectedIndex = 0;
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
