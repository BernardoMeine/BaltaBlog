using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.CategoryScreens;

public static class DeleteCategoryScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Excluir uma categoria");
    Console.WriteLine("-------------");

    Console.Write("Qual o id da categoria que deseja excluir?: ");
    int id = int.Parse(Console.ReadLine());

    Delete(id);
    Console.ReadKey();
    MenuCategoryScreen.Load();
  }

  public static void Delete(int id)
  {
    try
    {
      var repository = new Repository<Category>(Database.Connection);
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