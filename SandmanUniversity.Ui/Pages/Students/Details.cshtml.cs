using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Models.Students;
using SandmanUniversity.Queries.Students;

namespace SandmanUniversity.Ui.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly IMediator _mediator;

        public DetailsModel(ILogger<DetailsModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public DetailsViewModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(DetailsQuery query)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnGetAsync));
            if (ModelState.IsValid)
            {
                Student = await _mediator.Send(query);
            }

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}