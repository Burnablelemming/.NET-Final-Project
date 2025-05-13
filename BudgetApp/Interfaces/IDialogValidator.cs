using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces
{
    /// <summary>
    /// Defines the structure for dialog validation.
    /// </summary>
    internal interface IDialogValidator
    {
        /// <summary>
        /// Validates the input of a dialog.
        /// Returns true if the input is valid, false otherwise.
        /// </summary>
        /// <returns> True if the input is valid, falsae otherwise. </returns>
        bool ValidateDialog();
    }
}
