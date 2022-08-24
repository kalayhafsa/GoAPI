using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<GoContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = int.MaxValue;
});
builder.Services.AddScoped<MasterUsersService>();
builder.Services.AddScoped<DevicesService>();
builder.Services.AddScoped<SambaService>();
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.WithMethods("GET", "POST", "DELETE", "PUT");
    p.AllowAnyHeader();
});

app.MapPost("/login", async (HttpContext http, LoginRequest model, MasterUsersService service) =>
{
    var result = service.Login(model);
    if (!result.Success)
    {
        http.Response.StatusCode = 400;
        return Results.Json(result);
    }
    return Results.Ok(result);
});
app.MapGet("/info", async ([FromHeader(Name = "userName")] string userName, HttpContext http, DevicesService service) =>
{
    var result = service.GetInfo(userName);
    return Results.Ok(result);
});
app.MapPost("/sendData", async ([FromHeader(Name = "userName")] string userName, [FromHeader(Name = "type")] string type, HttpContext http, SambaService service) =>
{
    var form = http.Request.Form;
    if (form.Files.Count == 0)
    {
        http.Response.StatusCode = 400;
        return Results.Json("");
    }
    IFormFile file = form.Files[0];
    var result = service.SendData(userName, type, file);
    return Results.Ok(result);
});

app.Urls.Add("http://*:3000");
app.Run();
