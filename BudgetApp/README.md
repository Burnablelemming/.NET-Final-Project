# BudgetApp

BudgetApp is a WPF (Windows Presentation Foundation) application for managing budgets using the "waterfall" budgeting method. 
It allows users to track contributors, accounts, expenses, and incomes, making it easier to manage shared household or project finances.

## Features

- **Contributors**: Add, remove, and update contributors, including their percentage contributions to total expenses.
- **Accounts**: Manage checking and savings accounts with real-time balance updates.
- **Expenses**: Track recurring and one-time expenses like loans, groceries, insurance, and more.
- **Incomes**: Add incomes to contributors, including weekly, bi-weekly, and monthly options.

## Installation

1. Download the project files.
2. Open the project in Visual Studio.
3. Build and run the application.

## Usage

1. **Add Contributors**:
	- Click the "Add Contributor" button to add a new contributor with a name and percentage contribution.

2. **Add Accounts**:
    - Use the "Add Account" button to add checking or savings accounts.

3. **Add Expenses**:
    - Track regular expenses like mortgage, groceries, and insurance.

4. **Add Incomes
    - Add incomes to contributors to calculate their monthly contributions.

## Sample Data

**Contributors**:
```
Name,PercentageContribution
Alice,40
Bob,60
```

**Accounts**:
```
Name,Amount,Type
Main Checking,1500,Checking
Emergency Savings,3000,Savings
```

**Expenses**:
```
Name,Amount,Type
Mortgage,1200,Loans
Groceries,500,Groceries
Car Insurance,200,Insurance
```

**Incomes**:
```
Name,Amount,Type
Alice's Salary,1500,BiWeekly
Bob's Salary,6000,Monthly
```