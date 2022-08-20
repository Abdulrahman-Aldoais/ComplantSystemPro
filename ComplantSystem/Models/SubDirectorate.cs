using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class SubDirectorate
    {

        public SubDirectorate()
        {
            //SubDirectorateId = Guid.NewGuid().ToString();

            Users = new List<ApplicationUser>();
            Beneficiaries = new List<Beneficiarie>();
            UploadsComplainte = new List<Compalint>();
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Directorate Directorate { get; set; }

        //RelationShipes noe to many
        public virtual ICollection<Village> Villages { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<Beneficiarie> Beneficiaries { get; set; }
        public virtual List<Compalint> UploadsComplainte { get; set; }

    }
}
