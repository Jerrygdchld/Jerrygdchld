using Bogus;
using CulinaryAnalytics.Models.Entities.StoreFront;

namespace CulinaryAnalytics.Repositories.Bogus
{
    public static class RecipeFaker
    {
        public static List<Recipe> GetAll(int count, string companyCode)
        {
            var id = 0;
            var faker = new Faker<Recipe>()
                .RuleFor(x => x.Id, _ => id++)
                .RuleFor(x => x.Name, x => x.Commerce.Product())
                .RuleFor(x => x.CompanyCode, _ => companyCode)
                .RuleFor(x => x.Active, _ => true)
                .RuleFor(x => x.Description, x => x.Hacker.Phrase())
                .RuleFor(x => x.PhotoData, x => x.Image.DataUri(64, 64))
                ;

            return faker.Generate(count);
        }
    }
}
