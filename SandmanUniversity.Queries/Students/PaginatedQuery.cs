using AutoMapper;
using AutoMapper.QueryableExtensions;
using SandmanUniversity.Data;
using SandmanUniversity.Models.Students;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sandman.Extensions;
using Microsoft.Extensions.Logging;

namespace SandmanUniversity.Queries.Students
{
    public class PaginatedQuery : IRequest<PaginatedViewModel>
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string SortOrder { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
    public class PaginatedQueryHandler : IRequestHandler<PaginatedQuery, PaginatedViewModel>
    {
        private readonly ILogger<PaginatedQueryHandler> _logger;
        private readonly SchoolContext _context;
        private readonly IConfigurationProvider _configuration;

        public PaginatedQueryHandler(ILogger<PaginatedQueryHandler> logger, SchoolContext context, IConfigurationProvider configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public async Task<PaginatedViewModel> Handle(PaginatedQuery request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            var model = new PaginatedViewModel
            {
                CurrentSort = request.SortOrder,
                NameSortParm = string.IsNullOrEmpty(request.SortOrder) ? "name_desc" : "",
                DateSortParm = request.SortOrder == "Date" ? "date_desc" : "Date"
            };

            if (request.SearchString != null)
            {
                request.PageIndex = 1;
            }
            else
            {
                request.SearchString = request.CurrentFilter;
            }

            model.CurrentFilter = request.SearchString;
            model.SearchString = request.SearchString;

            IQueryable<Student> students = _context.Students;
            if (!string.IsNullOrEmpty(request.SearchString))
            {
                students = students.Where(s => s.LastName.Contains(request.SearchString)
                                               || s.FirstName.Contains(request.SearchString));
            }
            switch (request.SortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default: // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = request.PageSize ?? 3;
            int pageNumber = request.PageIndex ?? 1;
            model.Results = await students
                .ProjectTo<ViewModel>(_configuration)
                .PaginatedListAsync(pageNumber, pageSize, cancellationToken);

            _logger?.LogInformation("Students have been retrieved successfully.");
            return model;
        }
    }
}