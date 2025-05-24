using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Modules;

public static class UserModule
{
    public static IEndpointRouteBuilder RegisterUserModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/users", async (TicketDbContext db) =>
        {
            var users = await db.Users.ToListAsync();
            return Results.Ok(users);
        });

        return app;
    }
}
