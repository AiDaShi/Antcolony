using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class RoleTable
    {
        public RoleTable()
        {
            RolePostPower = new HashSet<RolePostPower>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }

        public virtual ICollection<RolePostPower> RolePostPower { get; set; }
    }
}
