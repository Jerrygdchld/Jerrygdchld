namespace CulinaryAnalytics.Models.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public int Creator { get; set; } = 9999;
        public int? Updator { get; set; }
        public int? Deletor { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }

    public abstract class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //ID
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            //Active
            builder.Property(x => x.Active).HasDefaultValue(true);
            //CreatedDate 
            builder.Property(x => x.DateCreated).ValueGeneratedOnAdd().IsRequired();
            //Updated Date
            builder.Property(x => x.DateUpdated).ValueGeneratedOnUpdate();
            builder.HasQueryFilter(x => x.Deleted == false);
        }
    }
}
