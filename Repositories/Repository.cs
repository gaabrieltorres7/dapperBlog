using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
  public class Repository<T> where T : class
  {
    private readonly SqlConnection _connection;

    public Repository(SqlConnection _connection) 
      => this._connection = _connection;

    public IEnumerable<T> GetAll() 
      => _connection.GetAll<T>();

  }
}