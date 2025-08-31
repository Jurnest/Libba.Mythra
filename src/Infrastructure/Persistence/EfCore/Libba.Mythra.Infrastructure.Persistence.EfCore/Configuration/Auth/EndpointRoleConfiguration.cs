using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class EndpointRoleConfiguration : BaseConfiguration<EndpointRoleEntity>
{
    public override void Configure(EntityTypeBuilder<EndpointRoleEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_ENDPOINT_ROLE");

        
        builder.Property(er => er.EndpointId).HasColumnName("AUTH_ENDPOINT_ID");
        builder.Property(er => er.RoleId).HasColumnName("AUTH_ROLE_ID");


        builder.HasKey(er => new { er.EndpointId, er.RoleId });


        builder.HasOne(er => er.Endpoint).WithMany(e => e.EndpointRoles).HasForeignKey(er => er.EndpointId);

        builder.HasOne(er => er.Role).WithMany(r => r.EndpointRoles).HasForeignKey(er => er.RoleId);
    }
}
