# FileProcessingSystem


The **FileProcessingSystem** is a .NET 8 application that allows User Registration and User Login and Validating the User.
Upload and process CSV files, store their contents in a SQL Server database, and track the processing status using unique `JobId` identifiers.


This project follows the **Repository Pattern** and uses **Entity Framework Core (Code-First Approach)**.

-----------------------------------------------------------------------------------------------------------


FileProcessingSystem/
│── FileProcessingSystem.API/ # API Layer (Controllers, Startup, Endpoints)
│── FileProcessingSystem.Service/ # Service Layer (Business Logic)
│── FileProcessingSystem.Data/ # Data Layer (Repositories, EF Core DbContext, Migrations)

--------------------------------------------------------------------------------------------------------------
Technologies Used

 **.NET 8**
- **Entity Framework Core** (Code-First Approach)
- **MS SQL Server**
- **CsvHelper** (CSV parsing)
- **Repository Pattern**
- **Dependency Injection**
- **REST API**


Features :

User Authentication – Register and login with validation.
Upload a CSV file from the filepath and store its data in the database.
----------------------------------------------------------------------------------------------------------

###API endpoints for:

User:

-- POST      /api/auth/register – Register a new user
-- POST      /api/auth/login – Login and get JWT token
-- POST      /api/file/start – Start CSV file processing (returns message)
--- **Get Processing Status**



## API Usage

### User Register

POST
https://localhost:7126/api/FileProcessing/register

Sample Request:

{
  "username": "akhil",
  "password": "akhil123",
  "mobileNumber": "97151161666",
  "createdDate": "2025-08-12T17:09:13.664Z"
}

Sample Response:

{
  "success": true,
  "message": "User registered"
}



### User Login Validation

POST
https://localhost:7126/api/FileProcessing/login

Sample Request :
{
  "username": "suraj",
  "password": "1234"
}

Sample Response:

{
  "success": false,
  "message": "Invalid credentials"
}


### File Processing 

POST
https://localhost:7126/api/FileProcessing/start

Sample Request :

"E:\\CSVFile\\employeedetails.csv"

Sample Response:

{
  "jobId": " 4 rows saved."
}


---------------------------------------------------------------------------------------------------------------------------------------------------------

### File Processing System Flow

1. **Register**: User registration and saving the user details.
2. **Login**: User login and validation.
3. **File Processing**: Reading the file from the filepath and save the datas into the table as json.




