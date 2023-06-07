using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.DAL.Interfaces;
using ToDoListStudy.Domain.Entity;
using ToDoListStudy.Domain.Enum;
using ToDoListStudy.Domain.Response;
using ToDoListStudy.Domain.ViewModels.Task;
using ToDoListStudy.Service.Interfaces;

namespace ToDoListStudy.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IBaseRepository<TaskEntity> _taskRepository;
        private ILogger<TaskService> _logger;

        public TaskService(IBaseRepository<TaskEntity> taskRepository,
            ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
        {
            try
            {
                _logger.LogInformation($"Запрос на создании задачи - {model.Title}");

                var task = await _taskRepository.GetAll()
                    .Where(x => x.Created.Date == DateTime.Today)
                    .FirstOrDefaultAsync(x => x.Title == model.Title);
                if (task != null)
                {
                    return new BaseResponse<TaskEntity>()
                    {
                        Description = "Задача с таким названием уже есть",
                        StatusCode = StatusCode.TaskIsHasAlready
                    };
                }

                task = new TaskEntity()
                {
                    Title = model.Title,
                    Description = model.Description,
                    IsDone = false,
                    Priority = model.Priority,
                    Created = DateTime.Now
                };
                await _taskRepository.Create(task);

                _logger.LogInformation($"Задача создалась: {task.Title} {task.Created}");
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Задача создалась",
                    StatusCode = StatusCode.OK
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[TaskService.Create]: {ex.Message}");
                return new BaseResponse<TaskEntity>()
                {
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
