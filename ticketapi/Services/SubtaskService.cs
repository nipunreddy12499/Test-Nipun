using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Services;

public class SubtaskService
{
    public async Task<TicketTask> AddSubtaskAsync(int ticketId, SubtaskDto dto, TicketDbContext db)
    {
        var subtask = new TicketTask
        {
            Description = dto.Description,
            TicketId = ticketId,
            UserId = dto.UserId
        };

        db.TicketTasks.Add(subtask);
        await db.SaveChangesAsync();
        return subtask;
    }

    public async Task<string> AssignUserToSubtaskAsync(int subtaskId, int userId, TicketDbContext db)
    {
        var subtask = await db.TicketTasks.FindAsync(subtaskId);
        if (subtask == null)
            return "Subtask not found.";

        subtask.UserId = userId;
        await db.SaveChangesAsync();
        return "User assigned to subtask.";
    }

}
