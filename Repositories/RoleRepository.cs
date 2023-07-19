using Dapper.Contrib.Extensions;
using DapperBlog.Models;
using Microsoft.Data.SqlClient;

namespace DapperBlog.Repositories
{
  public class RoleRepository
  {
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection _connection)
      => this._connection = _connection;

    public IEnumerable<Role> GetAll()
      => _connection.GetAll<Role>();
    
    public Role Get(int id)
      => _connection.Get<Role>(id);

  }
}