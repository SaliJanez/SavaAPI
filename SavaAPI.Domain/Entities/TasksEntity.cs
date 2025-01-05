using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavaAPI.Domain.Entities
{
    public class TasksEntity
    {
            public Guid Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public bool IsCompleted { get; set; }
            public DateTime DueDate { get; set; }
            public int Priority { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
    }
}
