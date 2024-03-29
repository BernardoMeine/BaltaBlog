using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.TagScreens;

public static class ListTagScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de tags");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuTagScreen.Load();
  }

  public static void List()
  {
    var repository = new Repository<Tag>(Database.Connection);
    var tags = repository.Get();

    foreach (var item in tags)
      Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
  }
}