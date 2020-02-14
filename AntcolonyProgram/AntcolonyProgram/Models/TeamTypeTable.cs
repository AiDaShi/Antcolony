using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class TeamTypeTable
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string RemarkTag { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
