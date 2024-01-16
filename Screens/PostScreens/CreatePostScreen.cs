using BaltaBlog.Models;
using BaltaBlog.Repositories;

namespace BaltaBlog.Screens.PostScreens;

public static class CreatePostScreen
{
  public static void Load()
  {
    Console.Clear();
    Console.WriteLine("Nova Postagem");
    Console.WriteLine("--------------");

    Console.Write("Título: ");
    string title = Console.ReadLine();

    Console.Write("Resumo: ");
    string summary = Console.ReadLine();

    Console.Write("descrição do post: ");
    string body = Console.ReadLine();

    Console.Write("Slug: ");
    string slug = Console.ReadLine();

    Console.Write("ID da categoria associada: ");
    int categoryId = int.Parse(Console.ReadLine());

    Console.Write("ID do autor: ");
    int authorId = int.Parse(Console.ReadLine());

    // Crie uma instância de Post
    Post newPost = new()
    {
      AuthorId = authorId,
      Title = title,
      Summary = summary,
      Body = body,
      Slug = slug,
      CategoryId = categoryId
    };

    // Adicione a postagem à lista de postagens da categoria
    AddPostToCategory(newPost, categoryId);

    Console.ReadKey();
    // Volte para a tela do menu de postagens após criar a postagem
    MenuPostScreen.Load();
  }

  private static void AddPostToCategory(Post post, int categoryId)
  {
    var categoryRepository = new Repository<Category>(Database.Connection);
    var postRepository = new Repository<Post>(Database.Connection);

    // Obtém a categoria do banco de dados
    var category = categoryRepository.Get(categoryId);

    if (category != null)
    {
      // Insere a postagem no banco de dados
      postRepository.Create(post);

      // Adiciona a postagem à lista de postagens da categoria
      if (category.Posts == null)
      {
        category.Posts = new List<Post>();
      }
      category.Posts.Add(post);

      // Atualiza a categoria no banco de dados para persistir a associação
      categoryRepository.Update(category);

      Console.WriteLine("Post criado com sucesso");
    }
  }
}