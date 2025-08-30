using Libba.Mythra.Core.Domain.Entities.Auth;
using RepoDb;

namespace Libba.Mythra.Infrastructure.Persistence.RepoDb.Mapping.Auth;

public class UserMap : BaseEntityMap<UserEntity>
{
    protected override string GetTableName() => "AUTH_USER";

    public override void Configure()
    {
        base.Configure();

        FluentMapper.Entity<UserEntity>().Column(u => u.Name, "NAME")
                                      .Column(u => u.Surname, "SURNAME")
                                      .Column(u => u.Email, "EMAIL")
                                      .Column(u => u.Password, "PASSWORD")
                                      .Column(u => u.IsActive, "IS_ACTIVE");
    }
}
