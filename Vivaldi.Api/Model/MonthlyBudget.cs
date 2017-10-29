namespace Vivaldi.Api.Model
{
   public class MonthlyBudget : BaseEntity
   {
      public int Year { get; set; }
      public int Month { get; set; }
      public virtual Category Category { get; set; }
      public decimal PlannedBudget { get; set; }
      public decimal ActualBudget { get; set; }
   }
}
