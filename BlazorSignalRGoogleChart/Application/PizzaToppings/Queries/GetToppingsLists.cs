using BlazorSignalRGoogleChart.Domain.Entities;
using BlazorSignalRGoogleChart.Infrastructure.Contexts;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BlazorSignalRGoogleChart.Application.PizzaToppings.Queries
{
    public record GetToppingsListsQuery : IRequest<List<PizzaTopping>>
    {
    }
    public class GetToppingsListsHandler(ApplicationDbContext dapperRepository) : IRequestHandler<GetToppingsListsQuery, List<PizzaTopping>>
    {
        private readonly ApplicationDbContext _db = dapperRepository;
        public async ValueTask<List<PizzaTopping>> Handle(GetToppingsListsQuery request, CancellationToken cancellationToken)
        {           
            return await _db.PizzaToppings.ToListAsync(cancellationToken: cancellationToken); ;
        }
    }
}
