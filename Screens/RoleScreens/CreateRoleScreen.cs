using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.RoleScreens;

public static class CreateRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Novo perfil");
    Console.WriteLine("-------------");
    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Create(new Role
    {
      Name = name,
      Slug = slug
    });
    Console.ReadKey();
    MenuRoleScreen.Load();
  }

  public static void Create(Role role)
  {
    try
    {
      var repository = new Repository<Role>(Database.Connection);
      repository.Create(role);
      Console.WriteLine("Perfil cadastrada com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível salvar o perfil");
      Console.WriteLine(ex.Message);
    }
  }
}