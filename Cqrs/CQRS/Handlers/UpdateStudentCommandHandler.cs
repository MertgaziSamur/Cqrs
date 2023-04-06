using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updatedStudent = _context.Students.Find(request.Id);
            updatedStudent.Age = request.Age;
            updatedStudent.Surname = request.Surname;
            updatedStudent.Name = request.Name;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
