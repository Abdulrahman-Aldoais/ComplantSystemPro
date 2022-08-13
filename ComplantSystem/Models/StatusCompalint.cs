﻿using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class StatusCompalint
    {
        //public StatusCompalint()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = " ";
        //RelationShipes one to many with UploadsComplainte and StatusCompalint
        public ICollection<Compalint> UploadsComplainte { get; set; }
    }
}