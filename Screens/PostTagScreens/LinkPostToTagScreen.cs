using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.PostTagScreens;

public static class LinkPostToTagScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Vincular um post a uma tag");
    Console.WriteLine("-------------");
    Console.Write("Id do post: ");
    int postId = int.Parse(Console.ReadLine());

    Console.Write("Id da tag: ");
    int tagId = int.Parse(Console.ReadLine());

    Link(postId, tagId);
    Console.ReadKey();
    MenuPostTagScreen.Load();
  }

  public static void Link(int postId, int tagId)
  {
    var repository = new TagRepository(Database.Connection);

    repository.AssociatePostWithTag(postId, tagId);
  }

}