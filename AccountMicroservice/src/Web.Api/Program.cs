using Application;
using Infrastructure;
using Infrastructure.Services;
using InventoryConsumer.Services;
using Web.Api.Extensions;
using Web.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

//.AddHostedService<ConsumerService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
