using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.CategoryScreens;

public static class CreateCategoryScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Nova categoria");
    Console.WriteLine("-------------");
    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Create(new Category
    {
      Name = name,
      Slug = slug
    });
    Console.ReadKey();
    MenuCategoryScreen.Load();
  }

  public static void Create(Category category)
  {
    try
    {
      var repository = new Repository<Category>(Database.Connection);
      repository.Create(category);
      Console.WriteLine("Categoria criada com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível salvar a categoria");
      Console.WriteLine(ex.Message);
    }
  }

}