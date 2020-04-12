using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Models.Courses;
using SandmanUniversity.Queries.Courses;

namespace SandmanUniversity.Ui.Pages.Courses
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

        public IList<ViewModel> Courses { get;set; }

        public async Task OnGetAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnGetAsync));
            Courses = await _mediator.Send(new ListQuery());
        }
    }
}
