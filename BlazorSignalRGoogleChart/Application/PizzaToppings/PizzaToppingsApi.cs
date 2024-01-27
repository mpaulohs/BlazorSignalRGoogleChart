using BlazorSignalRGoogleChart.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorSignalRGoogleChart.Application.PizzaToppings
{

    public static class PizzaToppingsApi
    {
        public static RouteGroupBuilder MapPizzaToppings(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/pizzatoppings");

            group.WithTags("PizzaToppinsg");

            group.MapGet("/", async (ApplicationDbContext db) =>
            {
                var toppings = await db.PizzaToppings.ToListAsync();
                return new
                {
                    cols = new[]
                        {
                            new { id = "", label = "Topping", pattern = "", type = "string" },
                            new { id = "", label = "Slices", pattern = "", type = "number" }
                        },
                    rows = toppings.Select(t => new Row
                    {
                        c =
                        [
                            new() { v = t.Topping, f = null },
                            new() { v = t.Slices.ToString(), f = null }
                        ]
                    }).ToArray()
                };
                
            });

            return group;
        }
    }

    public class ValueFormat
    {
        public string? v { get; set; }
        public string? f { get; set; }
    }

    public class Row
    {
        public required ValueFormat[] c { get; set; } 
    }
}
