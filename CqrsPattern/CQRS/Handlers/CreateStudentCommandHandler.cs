using CqrsPattern.CQRS.Commands;
using CqrsPattern.Data;

namespace CqrsPattern.CQRS.Handlers
{
	public class CreateStudentCommandHandler
	{
		private readonly StudentContext _context;

		public CreateStudentCommandHandler(StudentContext context)
		{
			_context = context;
		}
		public void Handle(CreateStudentCommand command)
		{
			_context.Students.Add(new Student { Age =command.Age,Name = command.Name,Surname=command.Surname});
			_context.SaveChanges();

		}
	}
}
