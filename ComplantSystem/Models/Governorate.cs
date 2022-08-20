﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public partial class Governorate
    {


        public Governorate()
        {
            //GovernorateId = Guid.NewGuid().ToString();
            Users = new List<ApplicationUser>();
            Beneficiaries = new List<Beneficiarie>();
            UploadsComplainte = new List<Compalint>();
        }
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Directorate> Directorates { get; set; }
        //public virtual List<User> Users { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Compalint> UploadsComplainte { get; set; }
        public virtual ICollection<Beneficiarie> Beneficiaries { get; set; }


    }
}
