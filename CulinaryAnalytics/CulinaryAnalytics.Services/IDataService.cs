using CulinaryAnalytics.Core;
using CulinaryAnalytics.Models.Entities;

namespace CulinaryAnalytics.Services
{
    public interface IDataService<T> : IRepository<T> where T : BaseEntity
    {
    }
}
