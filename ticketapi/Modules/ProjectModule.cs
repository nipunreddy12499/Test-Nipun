using Ticketapi.Data;
using Ticketapi.Models;
using Ticketapi.Services;

namespace Ticketapi.Modules;

public class ProjectModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/projects", async (ProjectService service, TicketDbContext db) => {
            return Results.Json(await service.GetProjects(db));
        });

        endpoints.MapPost("v1/projects/{projectId}/assign-user", async (
        int projectId,
        AssignUserDto dto,
        ProjectService service,
        TicketDbContext db
)       => {
                var success = await service.AssignUserToProject(projectId, dto.UserId, db);
                return success ? Results.Ok("User assigned to project.")
                    : Results.BadRequest("Project or User not found.");
});

    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ProjectService>();
    }
}