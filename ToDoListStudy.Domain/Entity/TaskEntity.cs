using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListStudy.Domain.Enum;

namespace ToDoListStudy.Domain.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Priority Priority { get; set; }
    }
}
