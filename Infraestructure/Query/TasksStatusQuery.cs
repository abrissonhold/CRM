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
        public async Task<IEnumerable<Domain.Entities.TaskStatus>> GetAll()
        {
            return await _context.TaskStatus.ToListAsync();
        }

        public async Task<Domain.Entities.TaskStatus> GetById(int id)
        {
            return await _context.TaskStatus.FindAsync(id);
        }
    }
}
