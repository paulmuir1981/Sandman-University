using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Students
{
    public class DetailsQuery : IRequest<DetailsViewModel>
    {
        [Required]
        public int? Id { get; set; }
    }
    public class DetailsQueryHandler : IRequestHandler<DetailsQuery, DetailsViewModel>
    {
        private readonly ILogger<DetailsQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IConfigurationProvider _configuration;

        public DetailsQueryHandler(ILogger<DetailsQueryHandler> logger, SchoolContext context, IConfigurationProvider configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<DetailsViewModel> Handle(DetailsQuery request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            return await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .ProjectTo<DetailsViewModel>(_configuration)
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        }
    }
}