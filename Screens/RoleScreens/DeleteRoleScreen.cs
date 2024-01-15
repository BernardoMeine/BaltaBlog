using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.RoleScreens;

public static class DeleteRoleScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Excluir um perfil");
    Console.WriteLine("-------------");

    Console.Write("Qual o id do perfil que deseja excluir?: ");
    int id = int.Parse(Console.ReadLine());

    Delete(id);
    Console.ReadKey();
    MenuRoleScreen.Load();
  }

  public static void Delete(int id)
  {
    try
    {
      var repository = new Repository<Role>(Database.Connection);
      repository.Delete(id);
      Console.WriteLine("Perfil excluido com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível excluir o perfil");
      Console.WriteLine(ex.Message);
    }
  }
}