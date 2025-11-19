# Warning Fixes

This document outlines the fixes applied to resolve the build warnings.

## Problem

The project had several build warnings that needed to be addressed. These warnings were related to potential null reference exceptions, incorrect use of `Html.Partial`, and nullable type conversions.

## Fixes

### 1. `HomeController.cs`

**Warning:** `CS8600: Converting null literal or possible null value to non-nullable type.`

**Old Code:**
```csharp
searchType = searchType?.Trim().ToLower();
```

**New Code:**
```csharp
searchType = searchType?.Trim().ToLower() ?? "";
```

### 2. `ProjectTask/Details.cshtml` and `ProjectTask/Delete.cshtml`

**Warning:** `CS8602: Dereference of a possibly null reference.`

**Old Code:**
```html
@Html.DisplayNameFor(model => model.Project.Name)
@Html.DisplayFor(model => model.Project.Name)
```

**New Code:**
```html
@Html.DisplayNameFor(model => model.Project!.Name)
@Html.DisplayFor(model => model.Project!.Name)
```

### 3. `ProjectTask/Index.cshtml` and `Project/Index.cshtml`

**Warning:** `CS8600: Converting null literal or possible null value to non-nullable type.`

**Old Code:**
```csharp
string searchString = ViewData["SearchString"] as string;
```

**New Code:**
```csharp
string? searchString = ViewData["SearchString"] as string;
```

### 4. `ProjectTaskController.cs`

**Warning:** `CS8602: Dereference of a possibly null reference.`

**Old Code:**
```csharp
taskQuery = taskQuery.Where(t =>
    t.Title.ToLower().Contains(searchString) ||
    (t.Description != null && t.Description.ToLower().Contains(searchString))
);
```

**New Code:**
```csharp
taskQuery = taskQuery.Where(t =>
    (t.Title != null && t.Title.ToLower().Contains(searchString)) ||
    (t.Description != null && t.Description.ToLower().Contains(searchString))
);
```

### 5. `_Layout.cshtml` and `_Header.cshtml`

**Warning:** `MVC1000: Use of IHtmlHelper.Partial may result in application deadlocks.`

**Old Code:**
```html
@Html.Partial("_Header")
@Html.Partial("_Footer")
@Html.Partial("_Navbar")
```

**New Code:**
```html
<partial name="_Header" />
<partial name="_Footer" />
<partial name="_Navbar" />
```
