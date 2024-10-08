﻿using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface ITaskQuery
    {
        public Task<IEnumerable<Tasks>> GetAll();
        public Task<Tasks> GetById(Guid id);

    }
}
