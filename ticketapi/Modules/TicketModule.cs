using Ticketapi.Models;
using Ticketapi.Services;
using Ticketapi.Data;

namespace Ticketapi.Modules;

public class TicketModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/v1/projects/{projectId}/tickets", async (int projectId, TicketDto dto, TicketService service, TicketDbContext db) =>
        {
            var ticket = await service.AddTicketAsync(projectId, dto, db);
            return Results.Ok(ticket);
        });

        endpoints.MapPost("v1/tickets/{ticketId}/assign-user", async (int ticketId, TicketAssignmentDto dto, TicketService service, TicketDbContext db) => {
            var result = await service.AssignTicketAsync(ticketId, dto, db);
            return Results.Ok(result);
        });

        endpoints.MapGet("/v1/tickets/assigned", async (TicketService service, TicketDbContext db) =>
        {
            var tickets = await service.GetAllAssignedTickets(db);
            return Results.Ok(tickets);
        });


    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<TicketService>();
        services.AddScoped<TicketService>();
    }
}
