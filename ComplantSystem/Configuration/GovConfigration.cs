using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class GovConfigration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.HasData(
                    new Governorate
                    {
                        Id = 1,
                        Name = "صنعاء",
                    },
                    new Governorate
                    {
                        Id = 2,
                        Name = " تعز",
                    },
                     new Society
                     {
                         Id = 3,
                         Name = "الحديدة",
                     }
                );
        }


    }

}