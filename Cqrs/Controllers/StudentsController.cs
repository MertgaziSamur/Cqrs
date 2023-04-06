﻿using System.Threading.Tasks;
using Cqrs.CQRS.Commands;
using Cqrs.CQRS.Handlers;
using Cqrs.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
