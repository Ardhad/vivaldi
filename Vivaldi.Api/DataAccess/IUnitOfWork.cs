namespace Vivaldi.Api.DataAccess
{
   public interface IUnitOfWork
   {
      void Commit();
      void Rollback();
   }
}
