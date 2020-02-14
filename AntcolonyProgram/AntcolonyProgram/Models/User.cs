using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealyName { get; set; }
        public string Pwd { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool State { get; set; }
        public string Image { get; set; }
        public int? ProjectId { get; set; }
        public int? ProjectTaskListId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectTaskList ProjectTaskList { get; set; }
    }
}
