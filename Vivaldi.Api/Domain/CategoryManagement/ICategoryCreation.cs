using Vivaldi.Api.Model;

namespace Vivaldi.Api.Domain.CategoryManagement
{
   public interface ICategoryCreation : IDomainService
   {
      Category Create(string name);
      void AssingParent(Category target, Category parent);
       void Save(Category newCategory);
   }
}