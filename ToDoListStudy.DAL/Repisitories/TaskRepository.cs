using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.DAL.Interfaces;
using ToDoListStudy.Domain.Entity;

namespace ToDoListStudy.DAL.Repisitories
{
    // Этот репозиторий - это список запросов к базе данных
    public class TaskRepository : IBaseRepository<TaskEntity>
    {

        private readonly AppDbContext _appDbContext;
        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Create(TaskEntity entity)
        {
            await _appDbContext.Tasks.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TaskEntity entity)
        {
            _appDbContext.Tasks.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<TaskEntity> GetAll()
        {
            return _appDbContext.Tasks;
        }

        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            _appDbContext.Tasks.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
