using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Domain.Budget;
using Vivaldi.Api.Model;
using Vivaldi.Api.Utils;

namespace Vivaldi.Domain.Budget
{
    public class MonthlyBudgetFiller : IMonthlyBudgetFiller
    {
        private readonly IMonthlyBudgetRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MonthlyBudgetFiller(IMonthlyBudgetRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public void FillPlannedBudget(Category category, BudgetPeriod period, decimal value)
        {
            var monthlyBudget = PrepareBudgetEntity(category, period);

            monthlyBudget.PlannedBudget = value;
            _repository.Update(monthlyBudget);

            _unitOfWork.Commit();
        }

        private MonthlyBudget PrepareBudgetEntity(Category category, BudgetPeriod period)
        {
            var monthlyBudget = _repository.GetForCategory(category, period);
            if (monthlyBudget == null)
            {
                // TODO czy entity z EF mogą mieć niedomyślne konstruktory?
                monthlyBudget = new MonthlyBudget
                {
                    Year = period.Year,
                    Month = period.Month,
                    Category = category
                };

                _repository.Insert(monthlyBudget);
            }

            return monthlyBudget;
        }

        public void FillActualBudget(Category category, BudgetPeriod period, decimal value)
        {
            var monthlyBudget = PrepareBudgetEntity(category, period);

            monthlyBudget.ActualBudget = value;
            _repository.Update(monthlyBudget);

            _unitOfWork.Commit();
        }
    }
}