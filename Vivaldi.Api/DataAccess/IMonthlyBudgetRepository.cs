using Vivaldi.Api.Model;
using Vivaldi.Api.Utils;

namespace Vivaldi.Api.DataAccess
{
    public interface IMonthlyBudgetRepository : IRepository<MonthlyBudget>
    {
        MonthlyBudget GetForCategory(Category category, BudgetPeriod period);
    }
}