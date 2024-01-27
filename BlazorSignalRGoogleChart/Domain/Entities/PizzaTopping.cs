namespace BlazorSignalRGoogleChart.Domain.Entities
{
    public class PizzaTopping
    {
        public int Id { get; set; }
        public string Topping { get; set; } = string.Empty;
        public int Slices { get; set; }
        public string ColorBtn { get; set; } = string.Empty;
    }
}
