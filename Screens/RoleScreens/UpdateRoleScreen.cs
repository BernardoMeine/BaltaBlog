using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.RoleScreens;

public static class UpdateRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Atualizar um perfil");
    Console.WriteLine("-------------");

    Console.Write("Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Update(new Role
    {
      Id = id,
      Name = name,
      Slug = slug
    });
    Console.ReadKey();
    MenuRoleScreen.Load();
  }

  public static void Update(Role role)
  {
    try
    {
      var repository = new Repository<Role>(Database.Connection);
      repository.Update(role);
      Console.WriteLine("Perfil atualizado com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível atualizar o perfil");
      Console.WriteLine(ex.Message);
    }
  }
}