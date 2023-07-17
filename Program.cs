using Dapper.Contrib.Extensions;
using DapperBlog.Models;
using Microsoft.Data.SqlClient;

public class Program 
{
  private const string CONNECTION_STRING = "Server=localhost,1433;Database=bLOG;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True";

  static void Main (string[] args) 
  {
    ReadUsers();
  }

  public static void ReadUsers() 
  {
    using (var connection = new SqlConnection(CONNECTION_STRING)) 
    {
      connection.Open();
      var users = connection.GetAll<User>();
      foreach (var user in users) 
      {
        Console.WriteLine(@$"ID: {user.Id} // Name: {user.Name} // Email: {user.Email}");
      }
    }

  }

}
