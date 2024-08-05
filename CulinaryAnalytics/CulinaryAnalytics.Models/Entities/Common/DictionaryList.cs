namespace CulinaryAnalytics.Models.Entities.Common
{
    public class DictionaryList : NamedEntity
    {
        public virtual ICollection<DictionaryListItem>? Items { get; set; }
    }
    public class DictionaryListConfiguration : NamedEntityConfigurations<DictionaryList>
    {
        public override void Configure(EntityTypeBuilder<DictionaryList> builder)
        {
            builder.ToTable("DictionaryLists", "Common");
            builder.HasMany(x => x.Items).WithOne(x => x.Dictionary);

            builder.HasData(
                new List<DictionaryList>
                {
                    new()
                    {
                        Id = 1,
                        Name = "States",
                        Description = "States",
                        LookupCode = "STATES"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Units of Measure",
                        Description = "Units of Measure",
                        LookupCode = "UOM"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Ingredient Types",
                        Description = "Ingredient Types",
                        LookupCode = "INGREDIENTTYPES"
                    },
                    new()
                    {
                        Id = 4,
                        Name = "Business Entity Types",
                        Description = "Business Entity Types",
                        LookupCode = "BUSINESSENTITYTYPES"
                    }
                }
                );

            base.Configure(builder);
        }
    }
}
