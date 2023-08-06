using CqrsPattern;
using CqrsPattern.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentContext>(options => options.UseSqlServer("Data Source =.; Database = StudentDb; integrated security = true;"));
builder.Services.AddControllers().AddNewtonsoftJson(opt => { opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
builder.Services.AddScoped<GetStudentByIdQueryHandler>();
var app = builder.Build();


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
