namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankTbl")]
    public partial class BankTbl
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Bank_Name { get; set; }

        [StringLength(10)]
        public string Bank_Abbreviation { get; set; }

        public int? Status { get; set; }
    }
}
