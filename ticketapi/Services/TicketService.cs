using Ticketapi.Models;
using Ticketapi.Data;
using Microsoft.EntityFrameworkCore;

namespace Ticketapi.Services;

public class TicketService
{
    public async Task<Ticket> AddTicketAsync(int projectId, TicketDto dto, TicketDbContext db)
    {
        var ticket = new Ticket
        {
            Description = dto.Description,
            ProjectId = projectId,
            UserId = dto.UserId
        };

        db.Tickets.Add(ticket);
        await db.SaveChangesAsync();
        return ticket;
    }
    public async Task<string> AssignTicketAsync(int ticketId, TicketAssignmentDto dto, TicketDbContext db)
    {
        var ticket = await db.Tickets.FindAsync(ticketId);
        if (ticket == null)
            return "Ticket not found";

        ticket.UserId = dto.UserId;
        await db.SaveChangesAsync();
        return "User assigned to ticket.";
    }
    public async Task<List<object>> GetAllAssignedTickets(TicketDbContext db)
    {
        return await db.Tickets
            .Where(t => t.UserId != 0)
            .Select(t => new
            {
                t.Id,
                t.Description,
                t.ProjectId,
                t.UserId
            })
            .ToListAsync<object>();
    }


}
