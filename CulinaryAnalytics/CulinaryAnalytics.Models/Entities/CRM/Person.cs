
namespace CulinaryAnalytics.Models.Entities.CRM
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AltPhone { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public long? LocationId { get; set; }

        public Location? Location { get; set; }
    }

    public class PersonConfiguration : BaseEntityConfigurations<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "CRM");
            builder.Property(x => x.FirstName).HasMaxLength(250);
            builder.Property(x => x.LastName).HasMaxLength(250);
            builder.Property(x => x.Title).HasMaxLength(250);
            builder.Property(x => x.Email).HasMaxLength(250);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.AltPhone).HasMaxLength(20);
            builder.HasOne(x => x.Location).WithMany(x => x.People).HasForeignKey(x => x.LocationId);
            base.Configure(builder);
        }
    }
}
