using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.UserScreens;

public static class UpdateUserScreen
{

  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Atualizar um usuário");
    Console.WriteLine("-------------");

    Console.Write("Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Nome: ");
    string name = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Update(new User
    {
      Id = id,
      Name = name,
      Email = email,
      Slug = slug
    });
    Console.ReadKey();
    MenuUserScreen.Load();
  }

  public static void Update(User user)
  {
    try
    {
      var repository = new Repository<User>(Database.Connection);

      // Recupera o usuário existente no banco de dados
      var existingUser = repository.Get(user.Id);

      // Verifica se o usuário existe
      if (existingUser != null)
      {
        // Atualiza apenas os campos desejados
        existingUser.Name = user.Name ?? existingUser.Name; // Se user.Name for nulo, mantém o valor existente
        existingUser.Email = user.Email ?? existingUser.Email;
        existingUser.Slug = user.Slug ?? existingUser.Slug;

        // Executa a atualização no banco de dados
        repository.Update(existingUser);

        Console.WriteLine("Usuário atualizado com sucesso");
      }
      else
      {
        Console.WriteLine("Usuário não encontrado");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível atualizar o usuário");
      Console.WriteLine(ex.Message);
    }
  }
}
