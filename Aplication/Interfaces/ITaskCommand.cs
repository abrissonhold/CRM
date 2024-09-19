using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface ITaskCommand
    {
        public Task InsertTask(Tasks task);
    }
}
