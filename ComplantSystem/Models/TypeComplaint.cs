using ComplantSystem.Models.Data.Base;
using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class TypeComplaint : IEntityBase
    {
        public TypeComplaint()
        {
            Id = Guid.NewGuid().ToString();
        }


        public string Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Type { get; set; }
        //public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual ApplicationUser UsersAddType { get; set; }
        public virtual ICollection<Compalint> UploadsComplainte { get; set; }

    }
}
