using COMP2139_ICE.Areas.ProjectManagement.Models;
using COMP2139_ICE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_ICE.Areas.ProjectManagement.Controller;

[Area("ProjectManagement")]
[Route("[area]/[controller]/[action]")]
public class ProjectCommentController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProjectCommentController> _logger;

    public ProjectCommentController(ApplicationDbContext context, ILogger<ProjectCommentController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: Get all comments for a specific project (AJAX endpoint)
    [HttpGet("{projectId:int}")]
    public async Task<IActionResult> GetComments(int projectId)
    {
        _logger.LogInformation("Fetching comments for project {ProjectId}", projectId);

        var comments = await _context.ProjectComments
            .Where(c => c.ProjectId == projectId)
            .OrderByDescending(c => c.DatePosted)
            .ToListAsync();

        return Json(comments);
    }

    // POST: Add a new comment (AJAX endpoint)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddComment([FromBody] ProjectComment comment)
    {
        _logger.LogInformation("Adding comment for project {ProjectId}", comment.ProjectId);

        if (ModelState.IsValid)
        {
            comment.DatePosted = DateTime.UtcNow;
            _context.ProjectComments.Add(comment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Comment {CommentId} added successfully", comment.ProjectCommentId);

            return Json(new { success = true, comment = comment });
        }

        _logger.LogWarning("Failed to add comment due to validation errors");
        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

    // DELETE: Delete a comment (AJAX endpoint)
    [HttpDelete("{id:int}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteComment(int id)
    {
        _logger.LogInformation("Deleting comment {CommentId}", id);

        var comment = await _context.ProjectComments.FindAsync(id);
        if (comment == null)
        {
            _logger.LogWarning("Comment {CommentId} not found", id);
            return Json(new { success = false, message = "Comment not found" });
        }

        _context.ProjectComments.Remove(comment);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Comment {CommentId} deleted successfully", id);

        return Json(new { success = true });
    }
}