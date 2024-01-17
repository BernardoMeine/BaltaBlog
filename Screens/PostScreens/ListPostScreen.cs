using BaltaBlog.Models;
using BaltaBlog.Repositories;
using BaltaBlog.Repositories;
using Dapper;

namespace BaltaBlog.Screens.PostScreens;

public static class ListPostScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Lista de posts");
    Console.WriteLine("-------------");
    List();
    ListWithCategories();
    ListWithTags();
    Console.ReadKey();
    MenuPostScreen.Load();
  }

  public static void List()
  {
    var repository = new Repository<Post>(Database.Connection);
    var posts = repository.Get();

    foreach (var item in posts)
      Console.WriteLine($"{item.Id} - {item.Title}, {item.Summary} , ({item.Slug})");
  }

  public static void ListWithCategories()
  {
    var postRepository = new Repository<Post>(Database.Connection);
    var categoryRepository = new Repository<Category>(Database.Connection);

    var posts = postRepository.Get();
    var categories = categoryRepository.Get().ToDictionary(c => c.Id, c => c.Name);

    foreach (var post in posts)
    {
      if (categories.TryGetValue(post.CategoryId, out string? value))
      {
        Console.WriteLine($"{post.Title}, (Categoria): {value}");
      }
    }
  }

  public static void ListWithTags()
  {
    var postTagRepository = new TagRepository(Database.Connection);

    postTagRepository.ListPostsWithTags();
  }
}