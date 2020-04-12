using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Models.Students;
using SandmanUniversity.Queries.Students;

namespace SandmanUniversity.Ui.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly IMediator _mediator;

        public AboutModel(ILogger<AboutModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IList<EnrollmentDateViewModel> EnrollmentDates { get; set; }

        public async Task OnGetAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnGetAsync));
            EnrollmentDates = await _mediator.Send(new GroupedByEnrollmentDateQuery());
        }
    }
}