using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.PostScreens;

public static class ListPostScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de posts");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuPostScreen.Load();
  }

  public static void List()
  {
    var repository = new Repository<Post>(Database.Connection);
    var categories = repository.Get();

    foreach (var item in categories)
      Console.WriteLine($"{item.Id} - {item.Title}, {item.Summary} , ({item.Slug})");
  }
}