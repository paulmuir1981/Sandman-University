using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Students
{
    public class DeleteQuery : IRequest<DeleteViewModel>
    {
        [Required]
        public int? Id { get; set; }
    }
    public class DeleteQueryHandler : IRequestHandler<DeleteQuery, DeleteViewModel>
    {
        private readonly ILogger<DeleteQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public DeleteQueryHandler(ILogger<DeleteQueryHandler> logger, SchoolContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteViewModel> Handle(DeleteQuery request, CancellationToken token = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            return _mapper.Map(await _context.Students.FindByKeyValueAsync(request.Id, token), new DeleteViewModel());
        }
    }
}
