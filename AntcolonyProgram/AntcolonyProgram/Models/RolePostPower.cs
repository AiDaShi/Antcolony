using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class RolePostPower
    {
        public int Id { get; set; }
        public short State { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public int? RoleTableId { get; set; }
        public int? PowerId { get; set; }

        public virtual Power Power { get; set; }
        public virtual RoleTable RoleTable { get; set; }
    }
}
