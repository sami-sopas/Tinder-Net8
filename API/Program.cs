using API.Extensions;
using API.Middleware;


var builder = WebApplication.CreateBuilder(args);

//Los servicios se refactorizaron a ApplicationServiceExtensions.cs, para solo llamar al metodo estatico
builder.Services.AddApplicationServices(builder.Configuration);

//JwtBearer auth (Configuration authentication)
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

//Evitar error de CORS 
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
