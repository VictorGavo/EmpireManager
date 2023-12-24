using Domain;
using MediatR;
using Persistence;

namespace Application.Territories
{
    public class Create
    {
        public class Command : IRequest
        {
            public Territory Territory {get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Territories.Add(request.Territory);

                await _context.SaveChangesAsync();
            }
        }
    }
}