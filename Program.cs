using Blog.Repositories;
using Dapper.Contrib.Extensions;
using DapperBlog.Models;
using DapperBlog.Repositories;
using Microsoft.Data.SqlClient;

public class Program 
{
  private const string CONNECTION_STRING = "Server=localhost,1433;Database=bLOG;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True";

  static void Main (string[] args) 
  {
    var connection = new SqlConnection(CONNECTION_STRING);
    connection.Open();

    //ReadUsers(connection);
    ReadUsersWithRoles(connection);
    //ReadRoles(connection);
    //ReadTags(connection);

    connection.Close();
  }

  public static void ReadUsers(SqlConnection connection) 
  {
    var repository = new Repository<User>(connection);
    var items = repository.GetAll();

    foreach (var user in items) 
      Console.WriteLine(user.Name);
  }

  public static void ReadUsersWithRoles(SqlConnection connection) 
  {
    var repository = new UserRepository(connection);
    var items = repository.ReadWithRole();

    foreach (var user in items) 
    {
      Console.WriteLine(user.Name);
      foreach (var role in user.Roles) 
        Console.WriteLine($"\t{role.Name}");
    }
  }

  public static void ReadRoles(SqlConnection connection) 
  {
    var repository = new Repository<Role>(connection);
    var items = repository.GetAll();

    foreach (var role in items) 
      Console.WriteLine(role.Name);
  }

  public static void ReadTags(SqlConnection connection) 
  {
    var repository = new Repository<Tag>(connection);
    var items = repository.GetAll();

    foreach (var tag in items) 
      Console.WriteLine(tag.Name);
  }

}
