using ComplantSystem.Const;
using ComplantSystem.Models.Data.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName,
            DateTime createdDate)
            : base(roleName)
        {
            base.Name = roleName;

        }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
