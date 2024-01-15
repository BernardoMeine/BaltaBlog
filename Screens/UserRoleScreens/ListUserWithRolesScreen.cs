using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.UserRoleScreens;

public static class ListUserWithRolesScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de usuários com perfis");
    Console.WriteLine("-------------");
    List();
    Console.ReadKey();
    MenuUserRoleScreen.Load();
  }

  public static void List()
  {
    var repository = new UserRepository(Database.Connection);
    var users = repository.GetWitRoles();

    foreach (var user in users)
    {
      if (user.Roles.Count != 0)
      {
        var rolesString = string.Join(", ", user.Roles.Select(role => role.Name));
        Console.WriteLine($"{user.Name}, {user.Email}, {rolesString}");
      }
    }
  }
}