using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamRelationUser = new HashSet<TeamRelationUser>();
            TeamRoleTable = new HashSet<TeamRoleTable>();
            TeamTypeTable = new HashSet<TeamTypeTable>();
        }

        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamInfo { get; set; }
        public string TeamLogo { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }
        public int TeamAdmin { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<TeamRelationUser> TeamRelationUser { get; set; }
        public virtual ICollection<TeamRoleTable> TeamRoleTable { get; set; }
        public virtual ICollection<TeamTypeTable> TeamTypeTable { get; set; }
    }
}
