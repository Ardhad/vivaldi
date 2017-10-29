using System.Web.Mvc;
using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Domain.Budget;
using Vivaldi.Api.Domain.CategoryManagement;

namespace Vivaldi.Web.Controllers
{
   public class HomeController : Controller
   {
      private readonly ICategoryCreation _categoryCreation;
       private readonly IMonthlyBudgetFiller _budgetFiller;


       public HomeController(ICategoryCreation categoryCreation, IMonthlyBudgetFiller budgetFiller)
       {
           _categoryCreation = categoryCreation;
           _budgetFiller = budgetFiller;
       }

      public ActionResult Index()
      {
         var a = _categoryCreation.Create("alejajo");
         _categoryCreation.Save(a);

         return View();
      }

      public ActionResult About()
      {
         ViewBag.Message = "Your application description page.";

         return View();
      }

      public ActionResult Contact()
      {
         ViewBag.Message = "Your contact page.";

         return View();
      }
   }
}