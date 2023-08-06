using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsPattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly GetStudentByIdQueryHandler _handler;

		public StudentsController(GetStudentByIdQueryHandler handler)
		{
			_handler = handler;
		}

		[HttpGet("{id}")]
		public IActionResult GetStudent(int id)
		{
			var result = _handler.Handle(new GetStudentByIdQuery(id));
			return Ok (result);
		}
	}
}
 