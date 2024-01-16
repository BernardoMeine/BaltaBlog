namespace BaltaBlog.Screens.PostScreens;

public static class MenuPostScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Gestão de posts");
    Console.WriteLine("---------------");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Listar Posts");
    Console.WriteLine("2 - Cadastrar um post");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
      case 1:
        ListPostScreen.Load();
        break;
      case 2:
        CreatePostScreen.Load();
        break;
      default: Load(); break;
    }
  }
}