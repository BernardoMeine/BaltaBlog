using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.TagScreens;

public static class DeleteTagScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Excluir uma tag");
    Console.WriteLine("-------------");

    Console.Write("Qual o id da tag que deseja excluir?: ");
    int id = int.Parse(Console.ReadLine());

    Delete(id);
    Console.ReadKey();
    MenuTagScreen.Load();
  }

  public static void Delete(int id)
  {
    try
    {
      var repository = new Repository<Tag>(Database.Connection);
      repository.Delete(id);
      Console.WriteLine("Tag excluida com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível excluir a tag");
      Console.WriteLine(ex.Message);
    }
  }
}