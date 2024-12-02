# TaskManagement

TaskManagement is a WPF application built using .NET Core. This project allows users to manage tasks, assign them to users, and track their progress.

## Features

- Task creation,  and deletion
- View task status and details

## Installation

To get started with the TaskManagement application:

1. Clone the repository:
```
   git clone https://github.com/Thusikaran/TaskManagement.git
 ```
2.Navigate to the project directory:
```
cd TaskManagement
```
3.Install necessary dependencies using NuGet:
```
dotnet restore
```
4.Build the project:
```
dotnet build
```
5.Run the application:
```
dotnet run
```
## Usage
Once the application is running, you can interact with it through the GUI to:

- Add new tasks
- View tasks based on their status
  
## Project Folder Structure
 ### Models:

- Contains the core business objects of the application (data models).
- Each model typically represents a specific entity (e.g., TaskModel representing a task in your task management application).
- These models often interact with services or databases.
### Views:

- Contains XAML files that define the user interface (UI).
- Views typically do not contain any logic, only the layout and controls for the application (e.g., buttons, text boxes, etc.).
- Views bind to ViewModels to display data and receive user input.
### ViewModels:

- The ViewModel acts as a middle layer between the View and Model. It handles the presentation logic, data binding, and commands for the view.
- The ViewModel exposes properties and commands that the View binds to.
- The ViewModel is responsible for the application logic, making it easy to test and maintain.
### Services:

- Contains classes that provide data-related functionality or external service communication 
- Services are typically injected into the ViewModels to retrieve data and perform operations.
### Helpers:

- Utility classes and helper methods can be placed here. For example, an ObservableObject class could be used to implement INotifyPropertyChanged for the ViewModel's properties, which notifies the View of changes.
### Resources:

- Contains XAML resources like styles, themes, and common UI elements (like buttons and templates) that can be shared across multiple views.
