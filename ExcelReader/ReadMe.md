# Excel Reader
_by __smkP13__ for __thecsharpacademy___

## Introduction
This is a simple application that retrieve data from an Excel file and present them at the user.<br>
No inputs are required.

## Requirements
- This is an application that will read data from an Excel spreadsheet into a database

- When the application starts, it should delete the database if it exists, create a new one, create all tables, read from Excel, seed into the database.

- You need to use EPPlus package

- You shouldn't read into Json first.

- You can use SQLite or SQL Server (or MySQL if you're using a Mac)

- Once the database is populated, you'll fetch data from it and show it in the console.

- You don't need any user input

- You should print messages to the console letting the user know what the app is doing at that moment (i.e. reading from excel; creating tables, etc)

- The application will be written for a known table, you don't need to make it dynamic.

- When submitting the project for review, you need to include an xls file that can be read by your application.

## Structure
The program run by itself.<br>
It first try to read from the AthleteSheet.xlsx file.<br>
Then it extracts the header and their value to the designed class.<br>
The database is deleted and recreated and refilled at every run.<br>
The data is then taken from the database and exposed in a simple table to the user.<p>
No inputs are necessary except to print the results and leave the program.

## Resources
- Excel Sample Data for Practice or Training Example: [Link](https://www.contextures.com/xlsampledata01.html)
- EPPlus - Excel Sheet for .NET: [Link](https://www.epplussoftware.com/)