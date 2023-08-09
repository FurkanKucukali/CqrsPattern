using CqrsPattern.CQRS.Commands;
using CqrsPattern.CQRS.Handlers;
using CqrsPattern.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsPattern.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler; 
		private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
		private readonly CreateStudentCommandHandler _createStudentCommandHandler;
		private	readonly RemoveStudentCommandHandler _removeStudentCommandHandler;

		public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler = null, RemoveStudentCommandHandler removeStudentCommandHandler = null)
		{
			_getStudentByIdQueryHandler = getStudentByIdQueryHandler;
			_getStudentsQueryHandler = getStudentsQueryHandler;
			_createStudentCommandHandler = createStudentCommandHandler;
			_removeStudentCommandHandler = removeStudentCommandHandler;
		}

		[HttpGet("{id}")]
		public IActionResult GetStudent(int id)
		{
			var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
			return Ok (result);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
			return Ok (result);

		}
		[HttpPost]
		public IActionResult Create(CreateStudentCommand command)
		{
			_createStudentCommandHandler.Handle(command);
			return Ok();
		}

		[HttpDelete]
		public IActionResult Remove(int id)
		{
			_removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
			return NoContent();
		}
	}
}
 