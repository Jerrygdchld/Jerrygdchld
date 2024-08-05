using CulinaryAnalytics.Models.Entities.CRM;

namespace CulinaryAnalytics.Models.Entities.Common
{
    public class DictionaryListItem : NamedEntity
    {
        public long DictionaryListId { get; set; }
        public DictionaryList? Dictionary { get; set; }
        public virtual ICollection<BusinessEntity> BusinessEntities { get; set; } = [];
    }
    public class DictionaryListItemConfiguration : NamedEntityConfigurations<DictionaryListItem>
    {
        public override void Configure(EntityTypeBuilder<DictionaryListItem> builder)
        {
            builder.ToTable("DictionaryListItems", "Common");

            builder
                .HasOne(x => x.Dictionary)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.DictionaryListId)
                .IsRequired();

            builder.HasData(new List<DictionaryListItem>
            {
                new () { Id = 1, DictionaryListId = 1, Name = "Alabama", LookupCode = "AL", ExternalId = "AL" },
                new () { Id = 2, DictionaryListId = 1, Name = "Alaska", LookupCode = "AK", ExternalId = "AK" },
                new () { Id = 3, DictionaryListId = 1, Name = "Arizona", LookupCode = "AZ", ExternalId = "AZ" },
                new () { Id = 4, DictionaryListId = 1, Name = "Arkansas", LookupCode = "AR", ExternalId = "AR" },
                new () { Id = 5, DictionaryListId = 1, Name = "California", LookupCode = "CA", ExternalId = "CA" },
                new () { Id = 6, DictionaryListId = 1, Name = "Canal Zone", LookupCode = "CZ", ExternalId = "CZ" },
                new () { Id = 7, DictionaryListId = 1, Name = "Colorado", LookupCode = "CO", ExternalId = "CO" },
                new () { Id = 8, DictionaryListId = 1, Name = "Connecticut", LookupCode = "CT", ExternalId = "CT" },
                new () { Id = 9, DictionaryListId = 1, Name = "Delaware", LookupCode = "DE", ExternalId = "DE" },
                new () { Id = 10, DictionaryListId = 1, Name = "District of Columbia", LookupCode = "DC", ExternalId = "DC" },
                new () { Id = 11, DictionaryListId = 1, Name = "Florida", LookupCode = "FL", ExternalId = "FL" },
                new () { Id = 12, DictionaryListId = 1, Name = "Georgia", LookupCode = "GA", ExternalId = "GA" },
                new () { Id = 13, DictionaryListId = 1, Name = "Guam", LookupCode = "GU", ExternalId = "GU" },
                new () { Id = 14, DictionaryListId = 1, Name = "Hawaii", LookupCode = "HI", ExternalId = "HI" },
                new () { Id = 15, DictionaryListId = 1, Name = "Idaho", LookupCode = "ID", ExternalId = "ID" },
                new () { Id = 16, DictionaryListId = 1, Name = "Illinois", LookupCode = "IL", ExternalId = "IL" },
                new () { Id = 17, DictionaryListId = 1, Name = "Indiana", LookupCode = "IN", ExternalId = "IN" },
                new () { Id = 18, DictionaryListId = 1, Name = "Iowa", LookupCode = "IA", ExternalId = "IA" },
                new () { Id = 19, DictionaryListId = 1, Name = "Kansas", LookupCode = "KS", ExternalId = "KS" },
                new () { Id = 20, DictionaryListId = 1, Name = "Kentucky", LookupCode = "KY", ExternalId = "KY" },
                new () { Id = 21, DictionaryListId = 1, Name = "Louisiana", LookupCode = "LA", ExternalId = "LA" },
                new () { Id = 22, DictionaryListId = 1, Name = "Maine", LookupCode = "ME", ExternalId = "ME" },
                new () { Id = 23, DictionaryListId = 1, Name = "Maryland", LookupCode = "MD", ExternalId = "MD" },
                new () { Id = 24, DictionaryListId = 1, Name = "Massachusetts", LookupCode = "MA", ExternalId = "MA" },
                new () { Id = 25, DictionaryListId = 1, Name = "Michigan", LookupCode = "MI", ExternalId = "MI" },
                new () { Id = 26, DictionaryListId = 1, Name = "Minnesota", LookupCode = "MN", ExternalId = "MN" },
                new () { Id = 27, DictionaryListId = 1, Name = "Mississippi", LookupCode = "MS", ExternalId = "MS" },
                new () { Id = 28, DictionaryListId = 1, Name = "Missouri", LookupCode = "MO", ExternalId = "MO" },
                new () { Id = 29, DictionaryListId = 1, Name = "Montana", LookupCode = "MT", ExternalId = "MT" },
                new () { Id = 30, DictionaryListId = 1, Name = "Nebraska", LookupCode = "NE", ExternalId = "NE" },
                new () { Id = 31, DictionaryListId = 1, Name = "Nevada", LookupCode = "NV", ExternalId = "NV" },
                new () { Id = 32, DictionaryListId = 1, Name = "New Hampshire", LookupCode = "NH", ExternalId = "NH" },
                new () { Id = 33, DictionaryListId = 1, Name = "New Jersey", LookupCode = "NJ", ExternalId = "NJ" },
                new () { Id = 34, DictionaryListId = 1, Name = "New Mexico", LookupCode = "NM", ExternalId = "NM" },
                new () { Id = 35, DictionaryListId = 1, Name = "New York", LookupCode = "NY", ExternalId = "NY" },
                new () { Id = 36, DictionaryListId = 1, Name = "North Carolina", LookupCode = "NC", ExternalId = "NC" },
                new () { Id = 37, DictionaryListId = 1, Name = "North Dakota", LookupCode = "ND", ExternalId = "ND" },
                new () { Id = 38, DictionaryListId = 1, Name = "Ohio", LookupCode = "OH", ExternalId = "OH" },
                new () { Id = 39, DictionaryListId = 1, Name = "Oklahoma", LookupCode = "OK", ExternalId = "OK" },
                new () { Id = 40, DictionaryListId = 1, Name = "Oregon", LookupCode = "OR", ExternalId = "OR" },
                new () { Id = 41, DictionaryListId = 1, Name = "Pennsylvania", LookupCode = "PA", ExternalId = "PA" },
                new () { Id = 42, DictionaryListId = 1, Name = "Puerto Rico", LookupCode = "PR", ExternalId = "PR" },
                new () { Id = 43, DictionaryListId = 1, Name = "Rhode Island", LookupCode = "RI", ExternalId = "RI" },
                new () { Id = 44, DictionaryListId = 1, Name = "South Carolina", LookupCode = "SC", ExternalId = "SC" },
                new () { Id = 45, DictionaryListId = 1, Name = "South Dakota", LookupCode = "SD", ExternalId = "SD" },
                new () { Id = 46, DictionaryListId = 1, Name = "Tennessee", LookupCode = "TN", ExternalId = "TN" },
                new () { Id = 47, DictionaryListId = 1, Name = "Texas", LookupCode = "TX", ExternalId = "TX" },
                new () { Id = 48, DictionaryListId = 1, Name = "Utah", LookupCode = "UT", ExternalId = "UT" },
                new () { Id = 49, DictionaryListId = 1, Name = "Vermont", LookupCode = "VT", ExternalId = "VT" },
                new () { Id = 50, DictionaryListId = 1, Name = "Virgin Islands", LookupCode = "VI", ExternalId = "VI" },
                new () { Id = 51, DictionaryListId = 1, Name = "Virginia", LookupCode = "VA", ExternalId = "VA" },
                new () { Id = 52, DictionaryListId = 1, Name = "Washington", LookupCode = "WA", ExternalId = "WA" },
                new () { Id = 53, DictionaryListId = 1, Name = "West Virginia", LookupCode = "WV", ExternalId = "WV" },
                new () { Id = 54, DictionaryListId = 1, Name = "Wisconsin", LookupCode = "WI", ExternalId = "WI" },
                new () { Id = 55, DictionaryListId = 1, Name = "Wyoming", LookupCode = "WY", ExternalId = "WY" },
                new() { Id = 56, DictionaryListId = 2, Name = "Milligram", Description = "Milligram", LookupCode = "mg" },
                new() { Id = 57, DictionaryListId = 2, Name = "Gram", Description = "Gram", LookupCode = "g" },
                new() { Id = 58, DictionaryListId = 2, Name = "Kilogram", Description = "Kilogram", LookupCode = "kg" },
                new() { Id = 59, DictionaryListId = 2, Name = "Ounce", Description = "Ounce", LookupCode = "oz" },
                new() { Id = 60, DictionaryListId = 2, Name = "Pound", Description = "Pound", LookupCode = "lb" },
                new() { Id = 61, DictionaryListId = 2, Name = "Ton", Description = "Ton", LookupCode = "ton" },
                new() { Id = 62, DictionaryListId = 2, Name = "Cup", Description = "Cup", LookupCode = "cup" },
                new() { Id = 63, DictionaryListId = 2, Name = "Table Spoon", Description = "Table Spoon", LookupCode = "ts" },
                new() { Id = 64, DictionaryListId = 2, Name = "Unit", Description = "Unit", LookupCode = "unit" },
                new() { Id = 65, DictionaryListId = 3, Name = "Vegetable", Description = "Vegetable", LookupCode = "VEG" },
                new() { Id = 66, DictionaryListId = 3, Name = "Meat", Description = "Meat", LookupCode = "MEAT" },
                new() { Id = 67, DictionaryListId = 3, Name = "Herb", Description = "Herb", LookupCode = "HERB" },
                new() { Id = 68, DictionaryListId = 3, Name = "Fruit", Description = "Fruit", LookupCode = "FRUIT" },
                new() { Id = 69, DictionaryListId = 3, Name = "Grain", Description = "Grain", LookupCode = "GRAIN" },
                new() { Id = 70, DictionaryListId = 3, Name = "Spice", Description = "Spice", LookupCode = "SPICE" },
                new() { Id = 71, DictionaryListId = 4, Name = "Restaurant", Description = "Restaurant", LookupCode = "RESTAURANT" },
                new() { Id = 72, DictionaryListId = 4, Name = "Supplier", Description = "Supplier", LookupCode = "SUPPLIER" },
                new() { Id = 73, DictionaryListId = 4, Name = "Corporate", Description = "Corporate", LookupCode = "CORPORATE" },
                new() { Id = 74, DictionaryListId = 4, Name = "Reseller", Description = "Reseller", LookupCode = "RESELLER" }
            });
            base.Configure(builder);
        }
    }
}
