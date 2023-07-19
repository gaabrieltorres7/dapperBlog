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
   }
}