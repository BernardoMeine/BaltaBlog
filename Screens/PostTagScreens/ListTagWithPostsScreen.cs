using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.PostTagScreens;

public class ListTagWithPostsScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de tags com a contagem de posts");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuPostTagScreen.Load();
  }

  public static void List()
  {
    var repository = new TagRepository(Database.Connection);
    var tagsWithPosts = repository.GetTagsWithPost();

    foreach (var tag in tagsWithPosts)
    {
      if (tag.Posts.Count != 0)
      {
        Console.WriteLine($"{tag.Name}, {tag.Slug}, {tag.Posts.Count}");
      }
    }

  }
}