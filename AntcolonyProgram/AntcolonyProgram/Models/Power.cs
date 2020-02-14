using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class Power
    {
        public Power()
        {
            RolePostPower = new HashSet<RolePostPower>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Route { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? DeleteTime { get; set; }
        public short State { get; set; }
        public bool IsCompany { get; set; }
        public int? TeamRolePostPowerId { get; set; }

        public virtual TeamRolePostPower TeamRolePostPower { get; set; }
        public virtual ICollection<RolePostPower> RolePostPower { get; set; }
    }
}
