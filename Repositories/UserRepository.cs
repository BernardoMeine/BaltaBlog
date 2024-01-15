using BaltaBlog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace BaltaBlog.Repositories;

public class UserRepository(SqlConnection connection) : Repository<User>(connection)
{
  private readonly SqlConnection _connection = connection;

  public List<User> GetWitRoles()
  {
    var query = @"
        SELECT
            [User].*,
            [Role].*
        FROM
            [User]
        LEFT JOIN
            [UserRole] ON [UserRole].[UserId] = [User].[Id]
        LEFT JOIN 
            [Role] ON [UserRole].[RoleId] = [Role].[Id]
    ";

    var users = new List<User>();

    var items = _connection.Query<User, Role, User>(
      query,
      (user, role) =>
      {
        var usr = users.FirstOrDefault(x => x.Id == user.Id);
        if (usr == null)
        {
          usr = user;
          if (role != null)
            usr.Roles.Add(role);

          users.Add(usr);
        }
        else
        {
          usr.Roles.Add(role);
        }

        return user;
      }, splitOn: "Id");

    return users;
  }

  public void AssociateUserWithRole(int userId, int roleId)
  {
    try
    {
      var query = @"
            INSERT INTO [UserRole] (UserId, RoleId)
            VALUES (@UserId, @RoleId)
        ";

      _connection.Execute(query, new { UserId = userId, RoleId = roleId });
      Console.WriteLine("Usuário associado ao perfil com sucesso");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Não foi possível associar o usuário ao perfil");
      Console.WriteLine(ex.Message);
    }
  }

}