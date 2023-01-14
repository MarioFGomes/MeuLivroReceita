using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Extension;

    public static class RepositorioExtension
    {
        public static string GetConexa(this IConfiguration configurationManager)
        {
                var Conexao = configurationManager.GetConnectionString("Conexao");

               return Conexao;
        }

        public static string GetNomeDatabase(this IConfiguration configurationManager) 
        {
                var NomeDataBase = configurationManager.GetConnectionString("NomeDataBase");

                return NomeDataBase;
        }
    }

