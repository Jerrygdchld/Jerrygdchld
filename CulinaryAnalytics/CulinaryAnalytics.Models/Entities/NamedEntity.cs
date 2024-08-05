namespace CulinaryAnalytics.Models.Entities
{
    public abstract class NamedEntity : BaseEntity
    {
        public string ExternalId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LookupCode { get; set; } = string.Empty;
    }

    public abstract class NamedEntityConfigurations<TEntity> : BaseEntityConfigurations<TEntity>, IEntityTypeConfiguration<TEntity> where TEntity : NamedEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.ExternalId).HasMaxLength(100);
            builder.Property(x => x.LookupCode).HasMaxLength(100);
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            base.Configure(builder);
        }
    }
}
