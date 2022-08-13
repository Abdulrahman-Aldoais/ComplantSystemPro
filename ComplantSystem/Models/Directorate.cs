using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class Directorate
    {
        public Directorate()
        {
            //Id = Guid.NewGuid().ToString();
            SubDirectorates = new List<SubDirectorate>();
            Users = new List<ApplicationUser>();
            Beneficiaries = new List<Beneficiarie>();
            UploadsComplainte = new List<Compalint>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Governorate Governorate { get; set; }
        //RelationShipes one to many
        public virtual ICollection<SubDirectorate> SubDirectorates { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Beneficiarie> Beneficiaries { get; set; }
        public virtual ICollection<Compalint> UploadsComplainte { get; set; }

        //public virtual List<User> Users { get; set; }
        //public virtual List<Beneficiarie> Beneficiaries { get; set; }

    }

}

