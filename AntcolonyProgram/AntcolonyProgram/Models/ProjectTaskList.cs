using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectTaskList
    {
        public ProjectTaskList()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int TaskMainUser { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
