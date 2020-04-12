using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Students
{
    public class GroupedByEnrollmentDateQuery : IRequest<IList<EnrollmentDateViewModel>> { }

    public class GroupedByEnrollmentDateQueryHandler : IRequestHandler<GroupedByEnrollmentDateQuery, IList<EnrollmentDateViewModel>>
    {
        private readonly ILogger<GroupedByEnrollmentDateQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IConfigurationProvider _configuration;

        public GroupedByEnrollmentDateQueryHandler(ILogger<GroupedByEnrollmentDateQueryHandler> logger, SchoolContext context, IConfigurationProvider configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IList<EnrollmentDateViewModel>> Handle(GroupedByEnrollmentDateQuery request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));

            return await _context
                .Students
                .AsNoTracking()
                .GroupBy(x => x.EnrollmentDate)
                .ProjectToListAsync<EnrollmentDateViewModel>(_configuration, cancellationToken);
        }
    }
}
