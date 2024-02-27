
# Book Borrowing System 

The "Book Borrowing System" is a application that allows the user to see the list of books and their details.


## Technology
* Web APIs (Backend) – .Net / .Net Core
* UI (Frontend) – Angular
* Database – MSSQL Server
* Database ORM – Entity Framework

## Tools Required
* Visual Studio 2022
* Visual Studio Code
* SQL Server Management Studio
* Google Chrome / Mozilla Firefox
  
## Backend Setup

* Open BookBorrowSystemApi and open sln file with Visual Studio 2022.

* Now open appsettings.json file from solution explorer and change the Data Source inside the ConnectionStrings to make connection with Database.

* Now Open Tools >> Nuget Package Manager >> Package Manager Console select project BookBorrowDLL from the drop-down and run following commands separately.
  ```bash
  add-migration 'init'
  update-database
  ```
  Above commands will create the database in SQL Server Management Studio with the tables and some data.

* Now you can run the API.


## Frontend Setup

* Open BookBorrowUi folder in Visual Studio Code and run the following command in the terminal.
  ```bash
  npm install 
  ```
  Above command will install all the dependencies.

* Now to run the application run command.
  ```bash
  ng serve --open
  ```
  Above command will run as well as open the application with "http://localhost:4200"


 

