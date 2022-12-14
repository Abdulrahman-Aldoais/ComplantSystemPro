using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class BenefCommunication : IEntityBase
    {
        public BenefCommunication()
        {
            Id = Guid.NewGuid().ToString();
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required(ErrorMessage = "يجب ان تحدد الصنف ")]
        //[ForeignKey("TypeCommunication")]
        [Column(TypeName = "varchar(100)")]
        public int TypeCommunicationId { get; set; }
        //public virtual TypeCommunication TypeCommunication { get; set; }


        [Required(ErrorMessage = "قم بكتابة الوصف")]
        [MaxLength(300)]
        [Column(TypeName = "varchar(100)")]

        public string CommunDescribed { get; set; }

        public int BeneficiariesId { get; set; }
        public virtual ICollection<Beneficiarie> Beneficiaries { get; set; }
        public virtual ICollection<Communication_Counter> CommunicationCounters { get; set; }
    }
}
