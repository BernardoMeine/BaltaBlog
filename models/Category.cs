using Dapper.Contrib.Extensions;

namespace BaltaBlog.Models;

[Table("[Category]")]
public class Category
{
  public Category()
  {
    Posts = new List<Post>();
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public string Slug { get; set; }
  public IList<Post> Posts { get; set; }
}