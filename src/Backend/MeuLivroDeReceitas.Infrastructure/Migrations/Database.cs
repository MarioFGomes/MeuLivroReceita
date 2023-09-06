

using Dapper;
using Microsoft.Data.SqlClient;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

    public static class Database
    {
        public static void CriarDatabase(string conectionString,string nomeDatabase)
         {
            using var minhaconexao = new SqlConnection(conectionString);

        var parametro = new DynamicParameters();
        parametro.Add("nome", nomeDatabase);
        var registros=minhaconexao.Query("SELECT * FROM sys.databases WHERE name=@nome", parametro);

        if (!registros.Any())
        {
            minhaconexao.Execute($"CREATE DATABASE {nomeDatabase}");
        }
       }
    }

