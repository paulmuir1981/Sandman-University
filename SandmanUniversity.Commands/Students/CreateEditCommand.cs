using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Commands.Students
{
    public class CreateEditCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
    public class CreateEditCommandHandler : IRequestHandler<CreateEditCommand, int>
    {
        private readonly ILogger<CreateEditCommandHandler> _logger;
        private readonly SchoolContext _context;

        public CreateEditCommandHandler(ILogger<CreateEditCommandHandler> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<int> Handle(CreateEditCommand request, CancellationToken token = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));

            var entry = null as EntityEntry<Student>;
            if (request.Id > 0)
            {
                var student = await _context.Students.FindByKeyValueAsync(request.Id, token);

                if (student != null)
                {
                    entry = _context.Entry(student);
                }
            }
            else
            {
                entry = _context.Add(new Student());
            }
                
            entry?.CurrentValues.SetValues(request);
            await _context.SaveChangesAsync(token);
            return entry?.Entity.Id ?? 0;
        }
    }
}
