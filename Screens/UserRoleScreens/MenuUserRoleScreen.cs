namespace BaltaBlog.Screens.UserRoleScreens;

public static class MenuUserRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Gestão de usuários com perfis");
    Console.WriteLine("---------------");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Listar usuários com perfil");
    Console.WriteLine("2 - vincular um usuario a um perfil");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
      case 1:
        ListUserWithRolesScreen.Load();
        break;
      case 2:
        ListUserWithRolesScreen.Load();
        break;
      default:
        Load();
        break;
    }
  }
}