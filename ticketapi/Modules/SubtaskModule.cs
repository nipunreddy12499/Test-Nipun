using Ticketapi.Models;
using Ticketapi.Services;
using Ticketapi.Data;

namespace Ticketapi.Modules;

public class SubtaskModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/v1/tickets/{ticketId}/subtasks", async (int ticketId, SubtaskDto dto, SubtaskService service, TicketDbContext db) =>
        {
            var result = await service.AddSubtaskAsync(ticketId, dto, db);
            return Results.Ok(result);
        });

        endpoints.MapPost("v1/subtasks/{subtaskId}/assign-user", async (
            int subtaskId,
            TicketAssignmentDto dto,
            SubtaskService service,
            TicketDbContext db
        ) =>
        {
            var result = await service.AssignUserToSubtaskAsync(subtaskId, dto.UserId, db);
            return Results.Ok(result);
        });

    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<SubtaskService>();
    }
}
