using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWeb.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWeb.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
            new AppUserRole
            {
                UserId = Guid.Parse("6DE21C5E-6C86-4912-AB4D-5411B56657F2"),
                RoleId = Guid.Parse("1ABF6077-198E-40F0-9701-4BB4B89EE057")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("2251144B-5B3F-45E9-8297-10850635BA43"),
                RoleId = Guid.Parse("306D6673-3821-4774-8946-7451E9DDBF40")
            });
        }
    }
}
