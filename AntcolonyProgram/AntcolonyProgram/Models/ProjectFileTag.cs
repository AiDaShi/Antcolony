using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectFileTag
    {
        public ProjectFileTag()
        {
            ProjectFile = new HashSet<ProjectFile>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<ProjectFile> ProjectFile { get; set; }
    }
}
