using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Students
{
    public class CreateEditQuery : IRequest<CreateEditViewModel>
    {
        public int? Id { get; set; }
    }
    public class CreateEditQueryHandler : IRequestHandler<CreateEditQuery, CreateEditViewModel>
    {
        private readonly ILogger<CreateEditQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public CreateEditQueryHandler(ILogger<CreateEditQueryHandler> logger, SchoolContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateEditViewModel> Handle(CreateEditQuery request, CancellationToken token = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            var model = new CreateEditViewModel();

            if (request.Id.HasValue)
            {
                model = _mapper.Map(await _context.Students.FindByKeyValueAsync(request.Id, token), model);
            }
            return model;
        }
    }
}
