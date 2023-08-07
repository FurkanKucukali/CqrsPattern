using CqrsPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace CqrsPattern.CQRS.Handlers
{
    public class GetStudentsQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        {
            return _studentContext.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();



        }
    }
}
