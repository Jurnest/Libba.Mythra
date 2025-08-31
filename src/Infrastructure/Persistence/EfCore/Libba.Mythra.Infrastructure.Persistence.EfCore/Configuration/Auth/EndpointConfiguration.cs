using Libba.Mythra.Core.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libba.Mythra.Infrastructure.Persistence.EfCore.Configuration.Auth;

public class EndpointConfiguration : BaseConfiguration<EndpointEntity>
{
    public override void Configure(EntityTypeBuilder<EndpointEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("AUTH_ENDPOINT");

        builder.Property(u => u.ControllerName).HasColumnName("CONTROLLER_NAME").IsRequired();
        builder.Property(u => u.ActionName).HasColumnName("ACTION_NAME").IsRequired();
        builder.Property(u => u.HttpVerb).HasColumnName("HTTP_VERB").IsRequired();
        builder.Property(u => u.Path).HasColumnName("PATH").IsRequired();

        builder.HasMany(e => e.EndpointRoles).WithOne(er => er.Endpoint).HasForeignKey(er => er.EndpointId);
    }
}
