namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_employee
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string loginname { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? age { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(50)]
        public string dept_id { get; set; }

        [StringLength(50)]
        public string position { get; set; }

        public int? gender { get; set; }

        public int? married { get; set; }

        [StringLength(50)]
        public string salary { get; set; }

        [StringLength(50)]
        public string educational { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(1000)]
        public string remarks { get; set; }

        [StringLength(50)]
        public string school { get; set; }

        public DateTime? createtime { get; set; }

        [StringLength(50)]
        public string email { get; set; }
    }
}
