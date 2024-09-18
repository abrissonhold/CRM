﻿using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface ITasksStatusQuery
    {
        Task<IEnumerable<TasksStatus>> GetAll();

    }
}
