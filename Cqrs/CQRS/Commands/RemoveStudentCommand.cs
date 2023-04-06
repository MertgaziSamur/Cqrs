using MediatR;

namespace Cqrs.CQRS.Commands
{
    public class RemoveStudentCommand : IRequest
    {
        public RemoveStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
