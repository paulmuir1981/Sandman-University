using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SandmanUniversity.Commands.Students;
using SandmanUniversity.Models.Students;
using SandmanUniversity.Queries.Students;

namespace SandmanUniversity.Ui.Pages.Students
{
    public class CreateEdit : PageModel
    {
        private readonly ILogger<CreateEdit> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateEdit(ILogger<CreateEdit> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public CreateEditViewModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(CreateEditQuery query)
        {
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _mediator.Send(_mapper.Map(Student, new CreateEditCommand()));
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!StudentExists(Student.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                throw;
                //}
            }

            return RedirectToPage("./Index");
        }
    }
}