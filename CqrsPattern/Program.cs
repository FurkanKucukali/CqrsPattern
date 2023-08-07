using CqrsPattern.CQRS.Commands;
using CqrsPattern.CQRS.Handlers;
using CqrsPattern.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer("Data Source =.; Database = StudentDb; integrated security = true;"));
builder.Services.AddControllers().AddNewtonsoftJson(opt => { opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
var app = builder.Build();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
