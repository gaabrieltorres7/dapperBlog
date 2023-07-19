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
    // ReadUser();
    // CreateUser();
    // UpdateUser();
    // DeleteUser();

    connection.Close();
  }

  public static void ReadUsers(SqlConnection connection) 
  {
    var repository = new UserRepository(connection);
    var users = repository.GetAll();

    foreach (var user in users) 
      Console.WriteLine(user.Name);
  }

}
