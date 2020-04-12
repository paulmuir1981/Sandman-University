using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SandmanUniversity.Queries.Students;
using SandmanUniversity.Models.Students;
using Microsoft.Extensions.Logging;

namespace SandmanUniversity.Ui.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public PaginatedViewModel Students { get; set; }

        public async Task OnGetAsync(
            string sortOrder, 
            string currentFilter, 
            string searchString, 
            int? pageIndex)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnGetAsync));
            Students = await _mediator.Send(new PaginatedQuery { 
                CurrentFilter = currentFilter, 
                PageIndex = pageIndex, 
                SearchString = searchString, 
                SortOrder = sortOrder 
            });
        }
    }
}
