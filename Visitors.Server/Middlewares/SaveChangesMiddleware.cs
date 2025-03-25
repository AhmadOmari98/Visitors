using Visitors.Infra.Context;

namespace Visitors.Server.Middlewares
{
    public class SaveChangesMiddleware
    {
        private readonly RequestDelegate _next;

        public SaveChangesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            await _next(context);

            // Save changes only if there are any changes
            if (dbContext.ChangeTracker.HasChanges())
                await dbContext.SaveChangesAsync();
        }
    }
}
