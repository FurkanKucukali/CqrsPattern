using CqrsPattern.CQRS.Queries;
using CqrsPattern.CQRS.Results;
using CqrsPattern.Data;

namespace CqrsPattern.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student = _studentContext.Set<Student>().Find(query.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname,
            };
        }
    }
}
