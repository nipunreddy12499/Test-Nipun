using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Services;

public class ProjectService
{
    public async Task<List<Project>> GetProjects(TicketDbContext db)
    {
        return await db.Projects.Include(p => p.Users).ToListAsync();
    }
    public async Task<bool> AssignUserToProject(int projectId, int userId, TicketDbContext db)
    {
        var project = await db.Projects.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == projectId);
        var user = await db.Users.FindAsync(userId);

        if (project == null || user == null)
            return false;

        if (!project.Users.Contains(user))
        {
            project.Users.Add(user);
            await db.SaveChangesAsync();
        }

        return true;
    }

}