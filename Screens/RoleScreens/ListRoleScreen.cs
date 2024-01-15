using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.RoleScreens;

public static class ListRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de perfis");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuRoleScreen.Load();
  }

  public static void List()
  {
    var repository = new Repository<Role>(Database.Connection);
    var roles = repository.Get();

    foreach (var item in roles)
      Console.WriteLine($"{item.Id} - {item.Name}, ({item.Slug})");
  }
}