using BlazorSignalRGoogleChart.Domain.Entities;
using BlazorSignalRGoogleChart.Infrastructure.Contexts;
using Mediator;

namespace BlazorSignalRGoogleChart.Application.PizzaToppings.Queries
{
    public record RemoveSliceCommand : IRequest<int>
    {
        public int PizzaToppingId { get; set; } 
    }
    public class RemoveSliceCommandHandler(ApplicationDbContext dapperRepository) : IRequestHandler<RemoveSliceCommand, int>
    {
        private readonly ApplicationDbContext _db = dapperRepository; 
        public async ValueTask<int> Handle(RemoveSliceCommand request, CancellationToken cancellationToken)
        {
            PizzaTopping? t = await _db.PizzaToppings.FindAsync([request.PizzaToppingId], cancellationToken: cancellationToken);
            if(t != null)
            {
                t.Slices--;
                return  await _db.SaveChangesAsync(cancellationToken);                
            }
            return 0;
        }
    }
}
