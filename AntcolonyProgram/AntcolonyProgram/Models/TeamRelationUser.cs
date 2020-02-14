using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class TeamRelationUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TeamType { get; set; }
        public string UserRemark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool State { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
