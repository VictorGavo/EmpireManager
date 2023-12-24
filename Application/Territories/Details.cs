using Domain;
using MediatR;
using Persistence;

namespace Application.Territories
{
    public class Details
    {
        public class Query : IRequest<Territory>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Territory>
        {
            private readonly DataContext _context;


            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Territory> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Territories.FindAsync(request.Id);
            }

        }
    }
}