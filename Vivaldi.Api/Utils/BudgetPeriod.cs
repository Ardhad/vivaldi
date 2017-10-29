namespace Vivaldi.Api.Utils
{
    public class BudgetPeriod
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public BudgetPeriod(int year, int month)
        {
            Year = year;
            Month = month;
        }
    }
}