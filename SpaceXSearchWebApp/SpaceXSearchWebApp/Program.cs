
using Microsoft.Net.Http.Headers;
using SpaceXSearchWebApp.Common.Registrations;
using SpaceXSearchWebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowAnyOrigin()
                   .WithExposedHeaders(
                       HeaderNames.ETag))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseRouting();
//app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
