# HMCTS Task Manager

## Overview

A task management application built with ASP.NET Core MVC and Entity Framework Core as part of the 
HMCTS DTS Developer Technical Test.

The application allows users to create, view, update, and delete tasks through a clean web interface.

## Features

- Create new tasks
- View all tasks
- Update task status
- Delete tasks
- Form validation for required fields
- Dropdown status selection (no free text)
- SQLite database persistence
- Basic error handling
- Unit tests for controller actions

## Technologies Used

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQLite
- Bootstrap 5
- xUnit

## Running the Application

### 1. Clone the Repository
Run the following command in a terminal (e.g Visual Studio Developer PowerShell)

```bash
git clone https://github.com/LGCodeLab/HMCTS_TaskManager.git
```

### 2. Navigate to the project folder

```bash
cd .\HMCTS_TaskManager\
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Install EF Core CLI tools (if not already installed)

```bash
dotnet tool install --global dotnet-ef
```

### 5. Apply database migrations

```bash
dotnet ef database update --project HMCTS_TaskManager/HMCTS_TaskManager.csproj
```
### 6. Run the application

```bash
dotnet run --project HMCTS_TaskManager/HMCTS_TaskManager.csproj
```

The application will start and be available at the local URL shown in the console output (for example, https://localhost:5001).

## Running Unit Tests
Run the following command from the project root

```bash
dotnet test
```