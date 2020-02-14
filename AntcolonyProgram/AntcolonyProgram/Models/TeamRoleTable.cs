using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class TeamRoleTable
    {
        public TeamRoleTable()
        {
            TeamRolePostPower = new HashSet<TeamRolePostPower>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<TeamRolePostPower> TeamRolePostPower { get; set; }
    }
}
