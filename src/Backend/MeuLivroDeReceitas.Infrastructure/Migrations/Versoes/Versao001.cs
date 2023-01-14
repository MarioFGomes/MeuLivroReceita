using FluentMigrator;
using MeuLivroDeReceitas.Infrastructure.Migrations;

namespace MeuLivroDeReceitas.Infrastructure.Versoes;

[Migration((long)NumeroVersoes.CriarTebelaUsuario, "Cria tabela usuario")]
public class Versao001 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        
        var tabela= VersaoBase.InsarirColunasPadrao(Create.Table("Usuarios"));

        tabela
              .WithColumn("Nome").AsString(100).NotNullable()
              .WithColumn("Email").AsString(150).NotNullable()
              .WithColumn("Senha").AsString(2000).NotNullable()
              .WithColumn("Telefone").AsString(15).NotNullable();
    }
}
