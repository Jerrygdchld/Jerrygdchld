namespace CulinaryAnalytics.Models.Entities.StoreFront
{
    public class Recipe : NamedEntity
    {
        public string CompanyCode { get; set; } = string.Empty;
        public string? PhotoData { get; set; }
    }

    public class RecipeConfiguration : NamedEntityConfigurations<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes", "StoreFront");
            builder.Property(x => x.CompanyCode).HasMaxLength(20);
            base.Configure(builder);
        }
    }
}
