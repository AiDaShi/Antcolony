using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectType
    {
        public ProjectType()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }

        public virtual ICollection<Project> Project { get; set; }
    }
}
