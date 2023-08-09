using CqrsPattern.CQRS.Commands;
using CqrsPattern.Data;

namespace CqrsPattern.CQRS.Handlers
{
	public class UpdateStudentCommandHandler
	{
		private readonly StudentContext _context;
		public UpdateStudentCommandHandler(StudentContext context)
		{
			_context = context;
		}
		public void Handle(UpdateStudentCommand command)
		{
			var updatedStudent = _context.Students.Find(command.Id);
			updatedStudent.Age = command.Age;
			updatedStudent.Surname = command.Surname;
			updatedStudent.Name = command.Name;
			_context.SaveChanges();


		}
	}
}
