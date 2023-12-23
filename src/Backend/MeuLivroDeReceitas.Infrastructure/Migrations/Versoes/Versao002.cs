using FluentMigrator;
using MeuLivroDeReceitas.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Infrastructure.Migrations.Versoes;

[Migration((long)NumeroVersoes.CriarTabelaPost, "Cria tabela de posts")]
public class Versao002 : Migration
{
    public override void Down()
    {
        throw new NotImplementedException();
    }

    public override void Up()
    {
        var Post = VersaoBase.InsarirColunasPadrao(Create.Table("Posts"));

        Post
              .WithColumn("Conteudo").AsString(2000).NotNullable()
              .WithColumn("Legenda").AsString(255).NotNullable()
              .WithColumn("AuthorId").AsGuid().NotNullable();


        var PostComment = VersaoBase.InsarirColunasPadrao(Create.Table("PostComments"));

        PostComment
                      .WithColumn("PostId").AsGuid().NotNullable()
                      .WithColumn("UserId").AsGuid().NotNullable()
                      .WithColumn("Comentario").AsString(2000).NotNullable();


        var PostFile = VersaoBase.InsarirColunasPadrao(Create.Table("PostFile"));

        PostFile
                      .WithColumn("Originalname").AsString(255).NotNullable()
                      .WithColumn("filename").AsString(255).NotNullable()
                      .WithColumn("description").AsString(255).Nullable()
                      .WithColumn("url").AsString(255).Nullable();

        var PostReactions = VersaoBase.InsarirColunasPadrao(Create.Table("PostReactions"));

        PostReactions
                      .WithColumn("PostId").AsGuid().NotNullable()
                      .WithColumn("UserId").AsGuid().NotNullable()
                      .WithColumn("Types").AsInt32().NotNullable();

    }
}
