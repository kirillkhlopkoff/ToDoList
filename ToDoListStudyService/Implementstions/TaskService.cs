using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.DAL.Interfaces;
using ToDoListStudy.Domain.Entity;
using ToDoListStudy.Domain.Response;
using ToDoListStudy.Domain.ViewModels.Task;
using ToDoListStudyService.Interfaces;

namespace ToDoListStudyService.Implementstions
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskRepositoty;
        public TaskService(IBaseRepository<TaskEntity> taskRepository)
        {
            _taskRepositoty = taskRepository;
        }
        public Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
