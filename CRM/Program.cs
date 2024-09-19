using Aplication.Interfaces;
using Aplication.UseCase;
using Infraestructure.Command;
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

builder.Services.AddTransient<ITaskService, TasksStatusService>();
builder.Services.AddTransient<ITasksStatusQuery, TasksStatusQuery>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserQuery, UserQuery>();

builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IClientQuery, ClientQuery>();
builder.Services.AddTransient<IClientCommand, ClientCommand>();

builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IProjectQuery, ProjectQuery>();
builder.Services.AddTransient<IProjectCommand, ProjectCommand>();

builder.Services.AddTransient<IInteractionService, InteractionService>();
builder.Services.AddTransient<IInteractionQuery, InteractionQuery>();
builder.Services.AddTransient<IInteractionCommand, InteractionCommand>();

builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ITaskQuery, TaskQuery>();
builder.Services.AddTransient<ITaskCommand, TaskCommand>();

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
