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

Filters:
completed (boolean): Filter tasks by completion status. Use completed=true to retrieve completed tasks and completed=false for pending tasks.
sort_by (string): Sort tasks by a specific field. Valid options are:
createdDate: Sorts tasks by creation date (ascending by default). Add &sort_by=createdDate-desc for descending order.
dueDate: Sorts tasks by due date (ascending by default). Add &sort_by=dueDate-desc for descending order.

- **Get All Tasks(default)**
  Use this request to retrieve all tasks:
  GET http://localhost:5000/api/tasks

- ***Get only completed tasks:***
GET http://localhost:5038/api/tasks/?completed=true

- ***Get all tasks sorted by creation date(descending):***
GET http://localhost:5038/api/tasks/?sort_by=-createdDate or ?sort_by=-dueDate

- ***Get completed tasks sorted by due date (ascending):***
GET http://localhost:5038/api/tasks/?completed=true&sort_by=dueDate

- **Create a New Task**
  Use this request to add a new task:
  POST http://localhost:5000/api/tasks
  Content-Type: application/json
  Body:
  {
    "taskDescription": "Finish the backend documentation",
    "dueDate": "2024-12-31T23:59:00Z",
    "completed": false,
    "createdDate": "2024-4-25T16:59:00Z"
  }

- **Update an Existing Task**
  Use this request to update a task identified by {id}:
  PUT http://localhost:5000/api/tasks/{id}
  Content-Type: application/json

- **Delete a Task**
  Use this request to delete a task identified by {id}:
  DELETE http://localhost:5000/api/tasks/{id}
