using BlazorSignalRGoogleChart.Domain.Entities;
using BlazorSignalRGoogleChart.Infrastructure.Contexts;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BlazorSignalRGoogleChart.Application.PizzaToppings.Queries
{
    public record AddSliceCommand : IRequest<int>
    {
        public int PizzaToppingId { get; set; } 
    }
    public class AddSliceCommandHandler(ApplicationDbContext dapperRepository) : IRequestHandler<AddSliceCommand, int>
    {
        private readonly ApplicationDbContext _db = dapperRepository;
        public async ValueTask<int> Handle(AddSliceCommand request, CancellationToken cancellationToken)
        {
            PizzaTopping? t = await _db.PizzaToppings.FindAsync([request.PizzaToppingId], cancellationToken: cancellationToken);
            if(t != null)
            {
                t.Slices++;
                return  await _db.SaveChangesAsync(cancellationToken);                
            }
            return 0;
        }
    }
}
