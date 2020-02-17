using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntcolonyProgram.JWT
{
    public class ReturnModel
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public TnToken Value { get; set; }
    }
    public class ReturnModelJwt
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
