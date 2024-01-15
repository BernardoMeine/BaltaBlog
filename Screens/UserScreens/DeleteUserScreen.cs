using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.UserScreens;

public static class DeleteUserScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Excluir uma tag");
    Console.WriteLine("-------------");

    Console.Write("Qual o id do usuário que deseja excluir?: ");
    int id = int.Parse(Console.ReadLine());

    Delete(id);
    Console.ReadKey();
    MenuUserScreen.Load();
  }

  public static void Delete(int id)
  {
    try
    {
      var repository = new Repository<User>(Database.Connection);
      repository.Delete(id);
      Console.WriteLine("Usuário excluida com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível excluir o usuário");
      Console.WriteLine(ex.Message);
    }
  }
}