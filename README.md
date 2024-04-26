# Tiny TodoList Backend with .NET

This repository contains the backend code for the TodoList iOS application, implemented using C# and ASP.NET Core. The backend is designed to manage tasks, allowing users to create, update, delete, and fetch tasks, with support for sorting and filtering capabilities.

## Features

- Create, update, delete, and retrieve tasks.
- Filter tasks by completion status.
- Sort tasks by created date or due date.
- Robust error handling for sorting and filtering parameters.

## Technologies

- **ASP.NET Core**: Used for creating the API.
- **MongoDB**: Used as the backend database to store task data.

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Postman](https://www.postman.com/downloads/) (Optional, for API testing)

### Installation

1. **Configure the Application:**
  Navigate to the appsettings.json file and replace the MongoDB connection string with your connection details:
  
   ```json
   "ConnectionStrings": {
    "MongoDB": "mongodb+srv://your-mongodb-url"
    }

2. **Build and Run the Application:**

   ```bash
   dotnet build
   dotnet run

### Usage

Use Postman or any other API testing tool to interact with the API. Here are some sample requests you can perform to test the functionality of the backend:

#### Filters

- `completed` (boolean): Filter tasks by their completion status. Use `?completed=true` to retrieve completed tasks and `?completed=false` for pending tasks.
- `sort_by` (string): Sort tasks by a specific field. Use `?sort_by=createdDate` for ascending order by creation date and `?sort_by=-createdDate` for descending order. Similarly, use `?sort_by=dueDate` and `?sort_by=-dueDate` for due date sorting.

#### API Endpoints

- **Get All Tasks(default)**
  Use this request to retrieve all tasks:
  GET <http://localhost:5000/api/tasks>
<br>

- **Get Only Completed Tasks**
GET <http://localhost:5038/api/tasks/?completed=true>
<br>

- **Get All Tasks Sorted by Creation Date (Descending)**
GET <http://localhost:5038/api/tasks/?sort_by=-createdDate>
<br>

- **Get Completed Tasks Sorted by Due Date (Ascending)**
GET <http://localhost:5038/api/tasks/?completed=true&sort_by=dueDate>
<br>
- **Create a New Task**
  Use this request to add a new task:
  POST <http://localhost:5000/api/tasks>
  Content-Type: application/json
  Body:
  {
    "taskDescription": "Finish the backend documentation",
    "dueDate": "2024-12-31T23:59:00Z",
    "completed": false,
    "createdDate": "2024-4-25T16:59:00Z"
  }
<br>
- **Update an Existing Task**
  Use this request to update a task identified by {id}:
  PUT <http://localhost:5000/api/tasks/{id}>
  Content-Type: application/json
<br>
- **Delete a Task**
  Use this request to delete a task identified by {id}:
  DELETE <http://localhost:5000/api/tasks/{id}>
