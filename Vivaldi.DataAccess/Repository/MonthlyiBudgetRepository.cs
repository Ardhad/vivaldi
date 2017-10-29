using System.Linq;
using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Model;
using Vivaldi.Api.Utils;

namespace Vivaldi.DataAccess.Repository
{
    public class MonthlyBudgetRepository : RepositoryBase<MonthlyBudget>, IMonthlyBudgetRepository
    {
        public MonthlyBudgetRepository(VivaldiDbContext dbContext) : base(dbContext)
        {
        }

        public MonthlyBudget GetForCategory(Category category, BudgetPeriod period)
        {
            return Query()
                .SingleOrDefault(x => x.Category.Equals(category)
                                      && x.Year == period.Year && x.Month == period.Month);
        }
    }
}