using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TasksStatusQuery : ITasksStatusQuery
    {
        private readonly AppDbContext _context;

        public TasksStatusQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TasksStatus>> GetAll()
        {
            return await _context.TaskStatus.ToListAsync();
        }

        public async Task<TasksStatus> GetById(int id)
        {
            return await _context.TaskStatus.FindAsync(id);
        }
    }
}
