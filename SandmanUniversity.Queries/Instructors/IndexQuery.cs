using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Instructors;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Queries.Instructors
{
    public class IndexQuery : IRequest<IndexViewModel>
    {
        public int? Id { get; set; }
        public int? CourseId { get; set; }
    }
    public class IndexQueryHandler : IRequestHandler<IndexQuery, IndexViewModel>
    {
        private readonly ILogger<IndexQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IConfigurationProvider _configuration;

        public IndexQueryHandler(ILogger<IndexQueryHandler> logger, SchoolContext context, IConfigurationProvider configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<IndexViewModel> Handle(IndexQuery request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));

            var instructors = await _context.Instructors
                .Include(i => i.CourseAssignments)
                .ThenInclude(c => c.Course)
                .OrderBy(i => i.LastName)
                .AsNoTracking()
                .ProjectToListAsync<ViewModel>(_configuration, cancellationToken);

            var courses = new List<Models.Courses.ViewModel>();
            var enrollments = new List<Models.Enrollments.ViewModel>();

            if (request.Id.HasValue)
            {
                courses = await _context.CourseAssignments
                    .Where(ca => ca.InstructorId == request.Id)
                    .Select(ca => ca.Course)
                    .AsNoTracking()
                    .ProjectToListAsync<Models.Courses.ViewModel>(_configuration, cancellationToken);

                if (request.CourseId.HasValue)
                {
                    enrollments = await _context.Enrollments
                        .Where(x => x.CourseId == request.CourseId)
                        .AsNoTracking()
                        .ProjectToListAsync<Models.Enrollments.ViewModel>(_configuration, cancellationToken);
                }
            }

            return new IndexViewModel
            {
                Instructors = instructors,
                Courses = courses,
                Enrollments = enrollments,
                InstructorId = request.Id,
                CourseId = request.CourseId
            };
        }
    }
}