using BaltaBlog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaBlog.Repositories;

public class TagRepository(SqlConnection connection) : Repository<User>(connection)
{
  private readonly SqlConnection _connection = connection;

  public void AssociatePostWithTag(int postId, int tagId)
  {
    try
    {
      var query = @"
            INSERT INTO [PostTag] (PostId, TagId)
            VALUES (@PostId, @TagId)
        ";

      _connection.Execute(query, new { PostId = postId, TagId = tagId });
      Console.WriteLine("Post associado a tag com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível associar o post a tag");
      Console.WriteLine(ex.Message);
    }
  }

  public List<Tag> GetTagsWithPost()
  {
    var query = @"
        SELECT
            [Tag].*,
            [Post].*
        FROM
            [Tag]
        LEFT JOIN
            [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
        LEFT JOIN
            [Post] ON [PostTag].[PostId] = [Post].[Id]
    ";

    var tags = new List<Tag>();

    var items = _connection.Query<Tag, Post, Tag>(
      query,
      (tag, post) =>
      {
        var tg = tags.FirstOrDefault(x => x.Id == tag.Id);
        if (tg == null)
        {
          tg = tag;
          if (post != null)
            tg.Posts.Add(post);

          tags.Add(tg);
        }
        else
        {
          tg.Posts.Add(post);
        }

        return tag;
      }, splitOn: "Id");

    return tags;
  }

  public void ListPostsWithTags()
  {
    var postRepository = new Repository<Post>(Database.Connection);

    var query = @"
        SELECT
            [Post].*,
            [Tag].*
        FROM
            [Post]
        LEFT JOIN
            [PostTag] ON [PostTag].[PostId] = [Post].[Id]
        LEFT JOIN
            [Tag] ON [PostTag].[TagId] = [Tag].[Id]
    ";

    var postTagDictionary = new Dictionary<int, List<Tag>>();

    _connection.Query<Post, Tag, Post>(
        query,
        (post, tag) =>
        {
          if (!postTagDictionary.TryGetValue(post.Id, out var postTags))
          {
            postTags = new List<Tag>();
            postTagDictionary.Add(post.Id, postTags);
          }

          if (tag != null)
          {
            postTags.Add(tag);
          }

          return post;
        },
        splitOn: "Id"
    );

    foreach (var (postId, postTags) in postTagDictionary)
    {
      var post = postRepository.Get(postId);
      var postTitle = post != null ? post.Title : "Título não encontrado";

      var tagsString =
        postTags != null
          &&
        postTags.Count != 0
          ?
        string.Join(", ", postTags.Select(t => t.Name))
          :
        "Nenhuma tag";
      Console.WriteLine($"Título do post: {postTitle}, (Tags): {tagsString}");
    }
  }

}