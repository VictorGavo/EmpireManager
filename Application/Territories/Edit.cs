using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Territories
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Territory Territory {get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var territory = await _context.Territories.FindAsync(request.Territory.Id);

                _mapper.Map(request.Territory, territory);
                
                await _context.SaveChangesAsync();
            }
        }
    }
}