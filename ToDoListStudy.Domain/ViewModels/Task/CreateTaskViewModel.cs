using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.Domain.Enum;

namespace ToDoListStudy.Domain.ViewModels.Task
{
    public class CreateTaskViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }
    }
}
