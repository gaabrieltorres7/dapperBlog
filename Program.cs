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
    //ReadUsersWithRoles(connection);
    //UpdateUser(connection);
    //CreateUser(connection);
    //DeleteUser(connection);
    //ReadRoles(connection);
    //CreateRole(connection);
    //UpdateRole(connection);
    //DeleteRole(connection);
    //ReadTags(connection);
    //CreateTag(connection);
    //UpdateTag(connection);
    //DeleteTag(connection);

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

  public static void UpdateUser(SqlConnection connection) 
  {
    var repository = new UserRepository(connection);
    var user = repository.Get(1);
    user.Name = "New Name";
    repository.Update(user);
    Console.WriteLine("User updated");
  }

  public static void CreateUser(SqlConnection connection) 
  {
    var repository = new Repository<User>(connection);
    var user = new User {
      Name = "New User",
      Email = "newuser@teste",
      PasswordHash = "HASH",
      Bio = "New User Bio",
      Image = "https://",
      Slug = "new-user",
    };
    repository.Create(user);
    Console.WriteLine("User created");
  }

  public static void DeleteUser(SqlConnection connection) 
  {
    var repository = new Repository<User>(connection);
    var user = repository.Get(3);
    repository.Delete(user);
    Console.WriteLine("User deleted");
  }

  public static void ReadRoles(SqlConnection connection) 
  {
    var repository = new Repository<Role>(connection);
    var items = repository.GetAll();

    foreach (var role in items) 
      Console.WriteLine(role.Name);
  }

  public static void CreateRole(SqlConnection connection) 
  {
    var repository = new Repository<Role>(connection);
    var role = new Role {
      Name = "New Role",
      Slug = "new-role",
    };
    repository.Create(role);
    Console.WriteLine("Role created");
  }

  public static void UpdateRole(SqlConnection connection) 
  {
    var repository = new Repository<Role>(connection);
    var role = repository.Get(1);
    role.Name = "New Role Name";
    repository.Update(role);
    Console.WriteLine("Role updated");
  }

  public static void DeleteRole(SqlConnection connection) 
  {
    var repository = new Repository<Role>(connection);
    var role = repository.Get(1);
    repository.Delete(role);
    Console.WriteLine("Role deleted");
  }

  public static void ReadTags(SqlConnection connection) 
  {
    var repository = new Repository<Tag>(connection);
    var items = repository.GetAll();

    foreach (var tag in items) 
      Console.WriteLine(tag.Name);
  }

  public static void CreateTag(SqlConnection connection) 
  {
    var repository = new Repository<Tag>(connection);
    var tag = new Tag {
      Name = "New Tag",
      Slug = "new-tag",
    };
    repository.Create(tag);
    Console.WriteLine("Tag created");
  }

  public static void UpdateTag(SqlConnection connection) 
  {
    var repository = new Repository<Tag>(connection);
    var tag = repository.Get(1);
    tag.Name = "New Tag Name";
    repository.Update(tag);
    Console.WriteLine("Tag updated");
  }

  public static void DeleteTag(SqlConnection connection) 
  {
    var repository = new Repository<Tag>(connection);
    var tag = repository.Get(1);
    repository.Delete(tag);
    Console.WriteLine("Tag deleted");
  }

}
