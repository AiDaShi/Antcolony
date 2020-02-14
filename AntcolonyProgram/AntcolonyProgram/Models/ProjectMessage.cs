using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class ProjectMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int Userid { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public int? Parentid { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
