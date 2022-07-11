using Microsoft.EntityFrameworkCore;
using StudentsServise.StudentsData;
using StudentsServise.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddDbContext<StudentDataContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("StudentsDb") ?? string.Empty));


var app = builder.Build();


app.MapGrpcService<StudServise>();
app.MapGet("/",
    () =>
        "=)");

app.Run();