using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.Domain.Entity;
using ToDoListStudy.Domain.Response;
using ToDoListStudy.Domain.ViewModels.Task;

namespace ToDoListStudy.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model);
    }
}
