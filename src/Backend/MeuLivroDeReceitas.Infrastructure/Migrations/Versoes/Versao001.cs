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
        
        var User= VersaoBase.InsarirColunasPadrao(Create.Table("Usuarios"));

        User
              .WithColumn("Nome").AsString(100).NotNullable()
              .WithColumn("Email").AsString(150).NotNullable()
              .WithColumn("Senha").AsString(2000).NotNullable()
              .WithColumn("Telefone").AsString(50).NotNullable();
              

        var Perfil = VersaoBase.InsarirColunasPadrao(Create.Table("Perfil"));

        Perfil
              .WithColumn("Description").AsString(2000).Nullable()
              .WithColumn("Avatar_url").AsString(2000).Nullable()
              .WithColumn("About").AsString(1000).Nullable()
              .WithColumn("Location").AsString(200).Nullable()
              .WithColumn("Bio").AsString(200).Nullable()
              .WithColumn("Type").AsInt32().Nullable();


        var UsuarioImagens = VersaoBase.InsarirColunasPadrao(Create.Table("UsuarioImagens"));

        UsuarioImagens
              .WithColumn("UsuarioId").AsGuid().NotNullable()
              .WithColumn("Originalname").AsString(200).Nullable()
              .WithColumn("Filename").AsString(200).NotNullable()
              .WithColumn("Description").AsString(200).Nullable()
              .WithColumn("Url").AsString(200).Nullable();

        var Followers = VersaoBase.InsarirColunasPadrao(Create.Table("Followers"));

        Followers
              .WithColumn("UsuarioId").AsGuid().NotNullable()
              .WithColumn("SeguidorId").AsGuid().NotNullable();
             

        var Following = VersaoBase.InsarirColunasPadrao(Create.Table("Following"));

        Following
              .WithColumn("UsuarioId").AsGuid().NotNullable()
              .WithColumn("SeguidoId").AsGuid().NotNullable();

    }
}
