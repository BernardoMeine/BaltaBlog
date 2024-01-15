using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.UserScreens;

public static class CreateUserScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Novo usuário");
    Console.WriteLine("-------------");
    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    Console.Write("PasswordHash: ");
    string passwordHash = Console.ReadLine();

    Console.Write("Bio: ");
    string bio = Console.ReadLine();

    Console.Write("Image: ");
    string image = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Create(new User
    {
      Name = name,
      Email = email,
      PasswordHash = passwordHash,
      Bio = bio,
      Image = image,
      Slug = slug

    });
    Console.ReadKey();
    MenuUserScreen.Load();
  }

  public static void Create(User user)
  {
    try
    {
      var repository = new Repository<User>(Database.Connection);
      repository.Create(user);
      Console.WriteLine("Usuário cadastrada com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível salvar o usuário");
      Console.WriteLine(ex.Message);
    }
  }
}