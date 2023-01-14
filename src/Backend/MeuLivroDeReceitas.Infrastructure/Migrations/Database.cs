

using Dapper;
using MySqlConnector;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

    public static class Database
    {
        public static void CriarDatabase(string conectionString,string nomeDatabase)
         {
            using var minhaconexao = new MySqlConnection(conectionString);

        var parametro = new DynamicParameters();
        parametro.Add("nome", nomeDatabase);
        var registros=minhaconexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME=@nome",parametro);

        if (!registros.Any())
        {
            minhaconexao.Execute($"CREATE DATABASE {nomeDatabase}");
        }
       }
    }

