using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectFile = new HashSet<ProjectFile>();
            ProjectFileTag = new HashSet<ProjectFileTag>();
            ProjectMessage = new HashSet<ProjectMessage>();
            ProjectTaskList = new HashSet<ProjectTaskList>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public int MainUserId { get; set; }
        public int Teamid { get; set; }
        public string ProjectInfo { get; set; }
        public string ProjectImg { get; set; }
        public int SpeedOfProgress { get; set; }
        public string Edition { get; set; }
        public string GitHubUrl { get; set; }
        public short Priority { get; set; }
        public DateTime EstimatedTime { get; set; }
        public string WareHourseUrl { get; set; }
        public double Money { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectStateTableId { get; set; }

        public virtual ProjectStateTable ProjectStateTable { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual ICollection<ProjectFile> ProjectFile { get; set; }
        public virtual ICollection<ProjectFileTag> ProjectFileTag { get; set; }
        public virtual ICollection<ProjectMessage> ProjectMessage { get; set; }
        public virtual ICollection<ProjectTaskList> ProjectTaskList { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
