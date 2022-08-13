using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class TypeComplaintConfiguration : IEntityTypeConfiguration<TypeComplaint>
    {
        public void Configure(EntityTypeBuilder<TypeComplaint> builder)
        {
            builder.HasData(
                    new TypeComplaint
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "زراعية",
                        CreatedDate = DateTime.Now,
                    },
                    new TypeComplaint
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "فساد",
                        CreatedDate = DateTime.Now,

                    },
                     new TypeComplaint
                     {
                         Id = Guid.NewGuid().ToString(),
                         Type = "مماطلة",
                         CreatedDate = DateTime.Now,

                     },
                      new TypeComplaint
                      {
                          Id = Guid.NewGuid().ToString(),
                          Type = "إرتشاء",
                          CreatedDate = DateTime.Now,

                      }
                ); ;
        }

       
    }

}
