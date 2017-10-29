using Vivaldi.Api.Model;
using Vivaldi.Api.Utils;

namespace Vivaldi.Api.Domain.Budget
{
    public interface IMonthlyBudgetFiller : IDomainService
    {
        void FillPlannedBudget(Category category, BudgetPeriod period, decimal value);
        void FillActualBudget(Category category, BudgetPeriod period, decimal value);
    }
}