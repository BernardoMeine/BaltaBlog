using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.CategoryScreens;

public static class UpdateCategoryScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Atualizar uma categoria");
    Console.WriteLine("-------------");

    Console.Write("Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Update(new Category
    {
      Id = id,
      Name = name,
      Slug = slug
    });
    Console.ReadKey();
    MenuCategoryScreen.Load();
  }

  public static void Update(Category category)
  {
    try
    {
      var repository = new Repository<Category>(Database.Connection);
      repository.Update(category);
      Console.WriteLine("Categoria atualizada com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível atualizar a categoria");
      Console.WriteLine(ex.Message);
    }
  }

}