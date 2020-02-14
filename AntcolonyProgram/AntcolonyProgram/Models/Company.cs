using System;
using System.Collections.Generic;

namespace AntcolonyProgram.Models
{
    public partial class Company
    {
        public Company()
        {
            Team = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string CompanyIcon { get; set; }
        public string CompanyUrl { get; set; }
        public string CompanyAddress { get; set; }
        public string CorporaterepResentative { get; set; }
        public int CompanyMainUser { get; set; }
        public string CompanyTerritory { get; set; }
        public DateTime CompanyYearOfEstablishment { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public short State { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
