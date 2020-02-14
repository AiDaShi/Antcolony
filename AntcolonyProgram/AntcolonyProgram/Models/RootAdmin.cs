using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class RootAdmin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool State { get; set; }
    }
}
