using CulinaryAnalytics.Models.Entities.Common;

namespace CulinaryAnalytics.Models.Entities.CRM
{
    public class BusinessEntity : NamedEntity
    {
        public string Phone { get; set; } = string.Empty;
        public string AltPhone { get; set; } = string.Empty;
        public string WebSite { get; set; } = string.Empty;
        public string CompanyCode { get; set; } = string.Empty;
        public long? BusinessEntityTypeId { get; set; }
        public DictionaryListItem? BusinessEntityType { get; set; }
        public virtual ICollection<Location> Locations { get; set; } = [];
    }

    public class BusinessEntityConfiguration : NamedEntityConfigurations<BusinessEntity>
    {
        public override void Configure(EntityTypeBuilder<BusinessEntity> builder)
        {
            builder.ToTable("BusinessEntities", "CRM");
            builder.Property(x => x.WebSite).HasMaxLength(250);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.AltPhone).HasMaxLength(20);
            builder.Property(x => x.CompanyCode).HasMaxLength(20);
            builder.HasMany(x => x.Locations).WithOne(x => x.Business);
            builder.HasOne(x => x.BusinessEntityType).WithMany(x => x.BusinessEntities).HasForeignKey(x => x.BusinessEntityTypeId);
            base.Configure(builder);
        }
    }
}
