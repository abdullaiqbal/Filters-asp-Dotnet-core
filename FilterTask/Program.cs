using FilterTask.Service;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//This Will Apply On All The Actions

//Filters
//builder.Services.AddScoped<ControllerNameFilters>();
//builder.Services.AddScoped<ActionNameFilters>();
//builder.Services.AddScoped<MethodNameFilters>();
//builder.Services.AddTransient<MethodNameFilters>();
//builder.Services.AddTransient<ActionFilters>();
//builder.Services.AddScoped<actionFilters>();

builder.Services.AddScoped<IActionResponseTimeStopwatch, ActionResponseTimeStopwatch>();
//builder.Services.AddScoped<ControllerNameFilter>();

builder.Services.AddMvc(options =>
{
    //options.Filters.Add(new ActionFilters());
    options.Filters.Add(new AllFilters());
    //options.Filters.Add(new ControllerNameFilter());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
