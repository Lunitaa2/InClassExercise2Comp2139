# Search Functionality Fix

This document outlines the fixes applied to the search functionality.

## Problem

The search functionality was not working correctly when initiated from pages within the `ProjectManagement` area. This was due to two issues:

1.  The redirection from the general search action in `HomeController` to the area-specific search actions in `ProjectController` and `ProjectTaskController` was missing the `area` parameter.
2.  The search form in the navigation bar was not correctly routing to the `HomeController` when on a page within an area.

## Fixes

### 1. Update `HomeController.cs`

The `GeneralSearch` action in `HomeController.cs` was updated to include the `area` parameter in the `RedirectToAction` call.

**Old Code:**

```csharp
if (searchType == "projects")
{
    // Redirect to Project search
    return RedirectToAction(nameof(ProjectController.Search), "Project", new { searchString });
}
else if (searchType == "tasks")
{               
    // Redirect to ProjectTask search
    return RedirectToAction(nameof(ProjectTaskController.Search), "ProjectTask", new { searchString });             
}
```

**New Code:**

```csharp
if (searchType == "projects")
{
    // Redirect to Project search
    return RedirectToAction(nameof(ProjectController.Search), "Project", new { area = "ProjectManagement", searchString });
}
else if (searchType == "tasks")
{               
    // Redirect to ProjectTask search
    return RedirectToAction(nameof(ProjectTaskController.Search), "ProjectTask", new { area = "ProjectManagement", searchString });             
}
```

### 2. Update `_Navbar.cshtml`

The search form in `_Navbar.cshtml` was updated to include the `asp-area=""` attribute to ensure that the form always submits to the `HomeController` in the root area.

**Old Code:**

```html
<form class="d-flex align-items-center" asp-controller="Home" asp-action="GeneralSearch" method="get">
```

**New Code:**

```html
<form class="d-flex align-items-center" asp-area="" asp-controller="Home" asp-action="GeneralSearch" method="get">
```
