using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.TagScreens;

public static class UpdateTagScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Atualizar uma tag");
    Console.WriteLine("-------------");

    Console.Write("Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Update(new Tag
    {
      Id = id,
      Name = name,
      Slug = slug
    });
    Console.ReadKey();
    MenuTagScreen.Load();
  }

  public static void Update(Tag tag)
  {
    try
    {
      var repository = new Repository<Tag>(Database.Connection);
      repository.Update(tag);
      Console.WriteLine("Tag atualizada com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível atualizar a tag");
      Console.WriteLine(ex.Message);
    }
  }
}