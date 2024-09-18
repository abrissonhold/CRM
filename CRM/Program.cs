using Aplication.Interfaces;
using Aplication.UseCase;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mi contexto
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

//Inyección de dependencias
//CampaignType
builder.Services.AddTransient<ICampaignTypeService, CampaignTypeService>();
builder.Services.AddTransient<ICampaignTypeQuery, CampaignTypeQuery>();

builder.Services.AddTransient<IInteractionTypeService, InteractionTypeService>();
builder.Services.AddTransient<IInteractionTypeQuery, InteractionTypeQuery>();

builder.Services.AddTransient<ITasksStatusService, TasksStatusService>();
builder.Services.AddTransient<ITasksStatusQuery, TasksStatusQuery>();

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
