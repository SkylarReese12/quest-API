using System;
using System.Data.SqlClient;
using questAPI.Model;
namespace questAPI.DataLogic

{
    public interface IDatabase
    {
        SqlConnection GetConnection();
    }
}
