using Dapper.Contrib.Extensions;

namespace BaltaBlog.Models;

[Table("PostTag")]
public class PostTag
{
  [Write(false)] // Ignorar durante a gravação
  public int PostCount { get; set; }

  public int PostId { get; set; }
  public int TagId { get; set; }
}