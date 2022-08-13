using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            //Id = Guid.NewGuid().ToString();
            Directorates = new List<Directorate>();
            Users = new List<ApplicationUser>();
            Beneficiaries = new List<Beneficiarie>();
            UploadsComplainte = new List<Compalint>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        //RelationShipes noe to many
        public virtual ICollection<Directorate> Directorates { get; set; }
        //public virtual List<User> Users { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Compalint> UploadsComplainte { get; set; }
        public virtual ICollection<Beneficiarie> Beneficiaries { get; set; }


    }
}
