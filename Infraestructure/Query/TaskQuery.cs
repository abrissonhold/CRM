﻿using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TaskQuery : ITaskQuery
    {
        private readonly AppDbContext _context;

        public TaskQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks
                                .Include(t => t.User)
                                .Include(t => t.TasksStatus)
                                .ToListAsync();
        }
        public async Task<Tasks> GetById(Guid id)
        {
            return await _context.Tasks
                                .Include(t => t.User)
                                .Include(t => t.TasksStatus)
                                .FirstOrDefaultAsync(t => t.TaskID == id);
        }
    }
}
