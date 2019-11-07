namespace ChewApp.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdministratorsTbl")]
    public partial class AdministratorsTbl
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Avatar { get; set; }

        public int? Status { get; set; }

        public string ResetPasswordCode { get; set; }
    }
}
