# SimpleToDoManager

Console-based to-do list application written in C#.  
Implements basic task management with persistent storage using SQLite and Entity Framework Core.

## Features

- Add a task  
- View all tasks (with completion status)  
- Mark task as completed  
- Delete a task  


## Project Structure

- `Program.cs` – entry point, service setup, DB initialization  
- `Menu.cs` – handles user input/output and menu navigation  
- `ToDoService.cs` – service layer with CRUD logic  
- `AppDbContext.cs` – EF Core DB context  
- `ToDoItem.cs` – data model  
- `IToDoService.cs` – service interface  

## Notes

- On first run, a local `todo.db` file is created automatically.
- Code is structured with separation of concerns and basic error handling

