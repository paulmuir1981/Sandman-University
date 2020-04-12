using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Models.Instructors;
using SandmanUniversity.Queries.Instructors;

namespace SandmanUniversity.Ui.Pages.Instructors
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

        public IndexViewModel IndexViewModel { get;set; }

        public async Task OnGetAsync(IndexQuery query)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnGetAsync));
            IndexViewModel = await _mediator.Send(query);
        }
    }
}
