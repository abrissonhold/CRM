using Aplication.Interfaces;
using Aplication.UseCase;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5501")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración del contexto de base de datos
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

// Inyección de dependencias
builder.Services.AddTransient<ICampaignTypeService, CampaignTypeService>();
builder.Services.AddTransient<ICampaignTypeQuery, CampaignTypeQuery>();

builder.Services.AddTransient<IInteractionTypeService, InteractionTypeService>();
builder.Services.AddTransient<IInteractionTypeQuery, InteractionTypeQuery>();

builder.Services.AddTransient<ITaskStatusService, TasksStatusService>();
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

// Habilitar Swagger en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
