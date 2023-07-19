using Dapper.Contrib.Extensions;
using DapperBlog.Models;
using Microsoft.Data.SqlClient;

namespace DapperBlog.Repositories
{
   public class UserRepository 
   {
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection _connection) 
      => this._connection = _connection;

    public IEnumerable<User> GetAll() 
      => _connection.GetAll<User>();
    
    public User Get(int id)
      => _connection.Get<User>(id);
    
    public void Create(User user)
    {
      user.Id = 0;
      _connection.Insert<User>(user);
    }

    public void Update(User user)
    {
      if(user.Id != 0)
        _connection.Update<User>(user);
    }

  }
}