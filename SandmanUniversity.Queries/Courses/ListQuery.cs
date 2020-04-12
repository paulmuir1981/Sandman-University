using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Courses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Courses
{
    public class ListQuery : IRequest<IList<ViewModel>> { }
    public class ListQueryHandler : IRequestHandler<ListQuery, IList<ViewModel>>
    {
        private readonly ILogger<ListQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IConfigurationProvider _configuration;

        public ListQueryHandler(ILogger<ListQueryHandler> logger, SchoolContext context, IConfigurationProvider configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IList<ViewModel>> Handle(ListQuery request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            return await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ProjectToListAsync<ViewModel>(_configuration, cancellationToken);
        }
    }
}