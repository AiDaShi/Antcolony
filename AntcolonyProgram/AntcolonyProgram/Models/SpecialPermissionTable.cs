using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class SpecialPermissionTable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SpecialId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public short State { get; set; }
    }
}
