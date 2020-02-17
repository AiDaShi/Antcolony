using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntcolonyProgram.JWT
{
    public class TnToken
    {
        public string TokenStr { get; set; }
        public DateTime Expires { get; set; }
        public string UserId { get; set; }
        public string img { get; set; }
    }
}
