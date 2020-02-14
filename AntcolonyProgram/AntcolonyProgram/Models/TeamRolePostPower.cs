using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class TeamRolePostPower
    {
        public TeamRolePostPower()
        {
            Power = new HashSet<Power>();
        }

        public int Id { get; set; }
        public short State { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public int TeamRoleTableId { get; set; }

        public virtual TeamRoleTable TeamRoleTable { get; set; }
        public virtual ICollection<Power> Power { get; set; }
    }
}
