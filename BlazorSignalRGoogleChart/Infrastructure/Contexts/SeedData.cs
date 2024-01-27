using BlazorSignalRGoogleChart.Domain.Entities;

namespace BlazorSignalRGoogleChart.Infrastructure.Contexts 
{
    public static class SeedData
    {
        public static async void Initialize(ApplicationDbContext db)
        {
            if (!db.PizzaToppings.Any())
            {
                var t1 = new PizzaTopping(){Slices = 0,Topping = "Mushrooms" };
                var t2 = new PizzaTopping() { Slices = 0, Topping = "Onions" };
                var t3 = new PizzaTopping() { Slices = 0, Topping = "Olives" };
                var t4 = new PizzaTopping() { Slices = 0, Topping = "Zucchini" };
                var t5 = new PizzaTopping() { Slices = 0, Topping = "Pepperoni" };
                await db.AddAsync(t1);
                await db.AddAsync(t2);
                await db.AddAsync(t3);
                await db.AddAsync(t4);
                await db.AddAsync(t5);
                await db.SaveChangesAsync();
            }
        }
    }
}
