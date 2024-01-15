using BaltaBlog.Screens.RoleScreens;
using BaltaBlog.Screens.TagScreens;
using BaltaBlog.Screens.UserRoleScreens;
using BaltaBlog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace BaltaBlog;

class Program
{
    private const string connectionString = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
    static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(connectionString);
        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();
    }

    private static void Load()
    {
        Console.Clear();
        Console.Clear();
        Console.WriteLine("Meu blog");
        Console.WriteLine("---------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tags");
        Console.WriteLine("5 - Gestão de usuário com perfil");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios");
        Console.WriteLine();
        Console.WriteLine();
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                MenuUserScreen.Load();
                break;
            case 2:
                MenuRoleScreen.Load();
                break;
            case 4:
                MenuTagScreen.Load();
                break;
            case 5:
                MenuUserRoleScreen.Load();
                break;
            default:
                Load();
                break;
        }
    }
}
