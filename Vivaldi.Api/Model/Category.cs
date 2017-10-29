namespace Vivaldi.Api.Model
{
   public class Category : BaseEntity
   {
      public string CategoryName { get; set; }
      public virtual Category Parent { get; set; }
      public bool IsVisible { get; set; }
    }
}
