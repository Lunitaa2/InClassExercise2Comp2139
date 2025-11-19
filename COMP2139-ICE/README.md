## Lab Summaries

Lab 1: Modify an existing project
- Create a simple homepage with a Home controller and Index view.
- Add an About page.
- Add FontAwesome to the project.
- Create a `.gitignore` file.

Lab 2: Create and list projects
- Create a `Project` model.
- Create a `ProjectsController` with `Index`, `Create`, and `Details` actions.
- Create views for the `Index`, `Create`, and `Details` actions.
- Update the layout to include a navigation link to the projects.

Lab 3: Part 1 - Integrate Entity Framework Core
- Install Entity Framework Core, the PostgreSQL provider, and the EF Core tools.
- Create a `ApplicationDbContext` class.
- Configure the database connection in `appsettings.json` and `Program.cs`.
- Create and apply an initial database migration.
- Update the `ProjectsController` to use the database context.

Lab 4: Part 2 - CRUD Operations for Projects
- Update the `ProjectsController` to handle POST requests for creating and editing projects.
- Add `Edit` and `Delete` actions to the `ProjectsController`.
- Create views for `Edit` and `Delete` actions.
- Update the `Project/Index.cshtml` page to include links for `Details`, `Edit`, and `Delete`.

Lab 5: Tasks
- Introduce a new `ProjectTask` entity.
- Implement basic task management (CRUD operations) for tasks within a project.
- Create a `ProjectTaskController`.
- Create views for task management.
- Update the `Project/Index.cshtml` to include a "View Tasks" button.

Lab 6: Advanced Controller Actions and Routing
- Implement search functionality for both projects and tasks.
- Implement custom routing using attributes.
- Add a general search bar to the navigation menu.
- Implement a custom 404 "Not Found" page.

Lab 7: Advanced View and Routing Techniques
- Re-organize the application by creating a "ProjectManagement" area.
- Move all project and task-related controllers, models, and views into the new area.
- Update routing to support the new area structure.
- Enhance model classes with data annotations for improved validation and display formatting.
- Create and use display templates to ensure consistent data presentation across different views.
- Refactor the layout by creating and using partial views for the header, footer, and navigation bar.
