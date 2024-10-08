﻿using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Command
{
    public class ProjectCommand : IProjectCommand
    {
        private readonly AppDbContext _context;

        public ProjectCommand(AppDbContext context)
        {
            _context = context;
        }
        public async Task InsertProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task InsertInteraction(Project project, Interaction interaction)
        {
            _context.Interactions.Add(interaction);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task InsertTask(Project project, Tasks task)
        {
            _context.Tasks.Add(task);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(Project project, Tasks task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.TaskID);
            existingTask.Name = task.Name;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;
            existingTask.AssignedTo = task.AssignedTo;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
