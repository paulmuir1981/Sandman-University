using MediatR;
using Microsoft.Extensions.Logging;
using Sandman.Extensions;
using SandmanUniversity.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SandmanUniversity.Commands.Students
{
    public class DeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly ILogger<DeleteCommandHandler> _logger;
        private readonly SchoolContext _context;

        public DeleteCommandHandler(ILogger<DeleteCommandHandler> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken = default)
        {
            _logger?.LogDebug("'{0}' has been invoked", nameof(Handle));
            var student = await _context.Students.FindByKeyValueAsync(request.Id, cancellationToken);
            var result = false;
            if (student != null)
            {
                _context.Students.Remove(student);
                result = await _context.SaveChangesAsync(cancellationToken) > 0;
            }
            return result;
        }
    }
}