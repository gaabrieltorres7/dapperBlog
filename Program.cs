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

    // ReadUsers();
    // ReadUser();
    // CreateUser();
    // UpdateUser();
    DeleteUser();

    connection.Close();
  }

  public static void ReadUsers(SqlConnection connection) 
  {
    var repository = new UserRepository(connection);
    var users = repository.GetAll();

    foreach (var user in users) 
      Console.WriteLine(user.Name);

  }

  public static void CreateUser() 
  {
      var user = new User() 
      {
        Bio = "Lucas",
        Email = "lucas@teste",
        Image = "https://",
        Name = "Lucas",
        PasswordHash = "HASH",
        Slug = "lucas"
      };
    using (var connection = new SqlConnection(CONNECTION_STRING)) 
    {
      connection.Open();
      connection.Insert<User>(user);
      Console.WriteLine("User created succesfully!");
    };
  }

  public static void UpdateUser() 
  {
    var user = new User() 
    {
      Id = 2,
      Bio = "Lucas Ronaldo",
      Email = "lucas@teste",
      Image = "https://",
      Name = "Luquinha",
      PasswordHash = "HASH",
      Slug = "luca"
    };
    using (var connection = new SqlConnection(CONNECTION_STRING)) 
    {
      connection.Open();
      connection.Update<User>(user);
      Console.WriteLine("User updated succesfully!");
    };
  }

  public static void DeleteUser() 
  {
    using (var connection = new SqlConnection(CONNECTION_STRING)) 
    {
      connection.Open();
      var user = connection.Get<User>(2);
      connection.Delete<User>(user);
      Console.WriteLine("User deleted succesfully!");
    };
  }
}
