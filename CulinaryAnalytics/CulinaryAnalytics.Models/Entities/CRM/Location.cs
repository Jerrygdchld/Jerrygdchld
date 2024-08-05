namespace CulinaryAnalytics.Models.Entities.CRM
{
    public class Location : NamedEntity
    {
        public long? BusinessEntityId { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AltPhone { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public BusinessEntity? Business { get; set; }
        public virtual ICollection<Person> People { get; set; } = [];
    }

    public class LocationConfiguration : NamedEntityConfigurations<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations", "CRM");
            builder.Property(x => x.StreetAddress).HasMaxLength(500);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.PostalCode).HasMaxLength(10);
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.WebSite).HasMaxLength(250);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.AltPhone).HasMaxLength(20);
            builder.Property(x => x.CompanyCode).HasMaxLength(20);
            builder.HasOne(x => x.Business).WithMany(x => x.Locations).HasForeignKey(x => x.BusinessEntityId);
            builder.HasMany(x => x.People).WithOne(x => x.Location);
            base.Configure(builder);
        }
    }
}
