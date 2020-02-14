using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectStateTable
    {
        public ProjectStateTable()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Project> Project { get; set; }
    }
}
