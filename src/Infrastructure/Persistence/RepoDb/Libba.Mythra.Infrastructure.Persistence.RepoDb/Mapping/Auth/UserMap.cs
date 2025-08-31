using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class UserMap : BaseEntityMap<UserEntity>
{
    protected override string GetTableName() => "AUTH_USER";

    public override void Configure()
    {
        base.Configure();

        EntityMapFluentDefinition<UserEntity> mapper = FluentMapper.Entity<UserEntity>();

        mapper.Column(u => u.Name, "NAME");
        mapper.Column(u => u.Surname, "SURNAME");
        mapper.Column(u => u.Email, "EMAIL");
        mapper.Column(u => u.Password, "PASSWORD");
        mapper.Column(u => u.IsActive, "IS_ACTIVE");
    }
}
