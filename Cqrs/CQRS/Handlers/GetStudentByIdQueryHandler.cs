﻿using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Queries;
using Cqrs.CQRS.Results;
using Cqrs.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cqrs.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request,
            CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname
            };
        }
    }
}
