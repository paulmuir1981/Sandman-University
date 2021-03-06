﻿using System.Threading.Tasks;
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
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DeleteModel(ILogger<DeleteModel> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public DeleteViewModel Student { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(DeleteQuery query, bool? saveChangesError = false)
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

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(OnPostAsync));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _mediator.Send(_mapper.Map(Student, new DeleteCommand()));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete", new { Student.Id, saveChangesError = true });
            }

            return RedirectToPage("./Index");
        }
    }
}