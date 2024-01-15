using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.CategoryScreens;

public static class ListCategoryScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de perfis");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuCategoryScreen.Load();
  }

  public static void List()
  {
    var repository = new Repository<Category>(Database.Connection);
    var roles = repository.Get();

    foreach (var item in roles)
      Console.WriteLine($"{item.Id} - {item.Name}, ({item.Slug})");
  }
}