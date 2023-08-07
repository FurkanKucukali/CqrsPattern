﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsPattern.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler; 
		private readonly GetStudentsQueryHandler _getStudentsQueryHandler;

		public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler)
		{
			_getStudentByIdQueryHandler = getStudentByIdQueryHandler;
			_getStudentsQueryHandler = getStudentsQueryHandler;
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
	}
}
 