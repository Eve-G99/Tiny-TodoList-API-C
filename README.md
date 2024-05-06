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
- **Docker**: Used to containerize the application and MongoDB for easy deployment and management.

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Postman](https://www.postman.com/downloads/) (Optional, for API testing)

### Installation

1. **Adjust server url as needed in launch.json:**

   ```bash
   "ASPNETCORE_URLS": "http://*:8080"

2. **Build and Run the Application:**

   ```bash
   docker-compose build
   docker-compose up

### Usage

Use Postman or any other API testing tool to interact with the API. Here are some sample requests you can perform to test the functionality of the backend:

#### Filters

- `completed` (boolean): Filter tasks by their completion status. Use `?completed=true` to retrieve completed tasks and `?completed=false` for pending tasks.
- `sort_by` (string): Sort tasks by a specific field. Use `?sort_by=createdDate` for ascending order by creation date and `?sort_by=-createdDate` for descending order. Similarly, use `?sort_by=dueDate` and `?sort_by=-dueDate` for due date sorting.

#### API Endpoints

- **Fetch All MeetingNotes**
  - `GET /api/tasks` - Retrieves all the tasks.
  
- **Filter MeetingNotes**
  - `GET /api/tasks/?completed=true` - Filter notes by complete status

- **Sort MeetingNotes**
  - `GET /api/tasks/?sort_by=-createdDate` - Sort notes in descending direction by createdDate
  - `GET /api/tasks/?sort_by=dueDate` - Sort notes in ascending direction by dueDate

- **Add a MeetingNote**
  - `POST /api/tasks` - Adds a new task note. Body requires `taskDescription`, `dueDate`, and `completed`.
  
- **Update a MeetingNote**
  - `PUT /api/tasks/:id` - Updates an existing task by ID. Body can include `taskDescription`, `dueDate`, and `completed`.
  
- **Delete a MeetingNote**
  - `DELETE /api/tasks/:id` - Deletes a task by ID.
