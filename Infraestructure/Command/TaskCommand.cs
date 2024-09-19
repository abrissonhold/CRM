using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class TaskCommand : ITaskCommand
    {
        private readonly AppDbContext _context;

        public TaskCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertTask(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

    }
}
