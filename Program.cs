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

    ReadUsers(connection);
    //ReadRoles(connection);
    // ReadUser();
    // CreateUser();
    // UpdateUser();
    // DeleteUser();

    connection.Close();
  }

  public static void ReadUsers(SqlConnection connection) 
  {
    var repository = new Repository<User>(connection);
    var users = repository.GetAll();

    foreach (var user in users) 
      Console.WriteLine(user.Name);
  }

  public static void ReadRoles(SqlConnection connection) 
  {
    var repository = new RoleRepository(connection);
    var roles = repository.GetAll();

    foreach (var role in roles) 
      Console.WriteLine(role.Name);
  }

}
