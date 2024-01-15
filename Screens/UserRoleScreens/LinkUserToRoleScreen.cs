using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.UserRoleScreens;

public static class LinkUserToRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Vincular usuário a perfil");
    Console.WriteLine("-------------");
    Console.Write("Id do usuário: ");
    int userId = int.Parse(Console.ReadLine());

    Console.Write("Id do perfil: ");
    int roleId = int.Parse(Console.ReadLine());

    Link(userId, roleId);
    Console.ReadKey();
    MenuUserRoleScreen.Load();
  }

  public static void Link(int userId, int roleId)
  {
    var repository = new UserRepository(Database.Connection);

    repository.AssociateUserWithRole(userId, roleId);
  }

}