using BaltaBlog.Models;
using BaltaBlog.Repositories;
using Dapper;

namespace BaltaBlog.Screens.CategoryScreens;

public static class ListCategoryScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de categorias");
    Console.WriteLine("-------------");
    List();
    ListPostsByCategory();
    Console.ReadKey();
    MenuCategoryScreen.Load();
  }

  public static void List()
  {
    var categoryRepository = new Repository<Category>(Database.Connection);

    var categories = categoryRepository.Get();

    foreach (var item in categories)
    {
      // Carrega manualmente as postagens para cada categoria
      string sql = "SELECT * FROM [Post] WHERE CategoryId = @CategoryId";
      item.Posts = Database.Connection.Query<Post>(sql, new { CategoryId = item.Id }).ToList();

      int postCount = item.Posts?.Count ?? 0;
      Console.WriteLine($"{item.Id} - {item.Name}, {postCount}, ({item.Slug})");
    }
  }

  public static void ListPostsByCategory()
  {
    var categoryRepository = new Repository<Category>(Database.Connection);

    var categories = categoryRepository.Get();

    foreach (var category in categories)
    {
      // Carrega os nomes dos posts para cada categoria
      string sql = @"
      SELECT 
        Post.Title 
      FROM 
        [Post] 
      INNER JOIN 
        [Category] 
      ON 
        Post.CategoryId = Category.Id 
      WHERE 
        Category.Id = @CategoryId";
      var postNames = Database.Connection.Query<string>(sql, new { CategoryId = category.Id }).ToList();

      Console.WriteLine($"{category.Name} Posts: {string.Join(", ", postNames)}");
    }
  }
}