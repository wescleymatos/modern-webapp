using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Map
{
    class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);
            Property(x => x.BirthDay);
            Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            Property(x => x.User.UserName).IsRequired().HasMaxLength(20);
            Property(x => x.User.Password).IsRequired().HasMaxLength(32).IsFixedLength();
        }
    }
}
