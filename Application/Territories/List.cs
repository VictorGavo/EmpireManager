using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Territories
{
    public class List
    {
        public class Query : IRequest<List<Territory>> {}

        public class Handler : IRequestHandler<Query, List<Territory>>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<Territory>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this.context.Territories.ToListAsync();
            }
        }
    }
}