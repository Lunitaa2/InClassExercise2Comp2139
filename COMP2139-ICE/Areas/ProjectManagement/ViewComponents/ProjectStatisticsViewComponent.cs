//Week 10 - Lab 9 ICE-2
//File name - ProjectStatisticsViewComponent.cs
using COMP2139_ICE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_ICE.Areas.ProjectManagement.ViewComponents;

/// <summary>
/// ViewComponent that displays overall project statistics (total count)
/// </summary>
public class ProjectStatisticsViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor with dependency injection for ApplicationDbContext
    /// </summary>
    public ProjectStatisticsViewComponent(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// InvokeAsync method that counts total projects and returns the count as model
    /// No parameters needed - this shows overall statistics, not individual project details
    /// </summary>
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Count the total number of projects in the database asynchronously
        // This is more efficient than loading all projects into memory
        var totalProjects = await _context.Projects.CountAsync();

        // Return the default view, passing the count (int) as the model
        return View(totalProjects);
    }
}
