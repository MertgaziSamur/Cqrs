using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Commands;
using Cqrs.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cqrs.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student
            {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
