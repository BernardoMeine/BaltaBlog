namespace BaltaBlog.Screens.PostTagScreens;

public static class MenuPostTagScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Gestão de post com tags");
    Console.WriteLine("---------------");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Listar tags por quantidade de posts");
    Console.WriteLine("2 - vincular um post a uma tag");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
      case 1:
        ListTagWithPostsScreen.Load();
        break;
      case 2:
        LinkPostToTagScreen.Load();
        break;
      default:
        Load();
        break;
    }
  }
}