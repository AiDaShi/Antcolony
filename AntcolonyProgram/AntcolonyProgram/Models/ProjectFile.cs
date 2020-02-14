using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string SuffixName { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProjectId { get; set; }
        public int ProjectFileTagId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ProjectFileTag ProjectFileTag { get; set; }
    }
}
