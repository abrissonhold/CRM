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

        public async Task UpdateTask(Tasks task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.TaskID);

            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.DueDate = task.DueDate;
                existingTask.AssignedTo = task.AssignedTo;
                existingTask.Status = task.Status;
                existingTask.ProjectID = task.ProjectID;

                _context.Tasks.Update(existingTask);

                await _context.SaveChangesAsync();
            }
        }
    }
}
