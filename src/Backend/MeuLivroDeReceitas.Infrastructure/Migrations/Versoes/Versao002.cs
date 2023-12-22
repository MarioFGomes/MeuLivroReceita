using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Versoes;

[Migration((long)NumeroVersoes.CriarTabelaReceitas, "Cria tabela de receitas")]
public class Versao002 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var User = VersaoBase.InsarirColunasPadrao(Create.Table("Usuarios"));

        User
              .WithColumn("Nome").AsString(100).NotNullable()
              .WithColumn("Email").AsString(150).NotNullable()
              .WithColumn("Senha").AsString(2000).NotNullable()
              .WithColumn("Telefone").AsString(50).NotNullable()
              .WithColumn("Avatar_url").AsString(2000).Nullable()
              .WithColumn("About").AsString(1000).Nullable()
              .WithColumn("Location").AsString(200).Nullable()
              .WithColumn("Bio").AsString(200).Nullable()
              .WithColumn("Perfilpublico").AsBoolean().Nullable();
    }
}
