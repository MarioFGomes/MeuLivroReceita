using FluentMigrator.Builders.Create.Table;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

public static class VersaoBase
{
        public static ICreateTableColumnOptionOrWithColumnSyntax InsarirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tabela)
        {

                return tabela.WithColumn("Id").AsInt64().PrimaryKey().Identity()
                         .WithColumn("DataRegisto").AsDateTime().NotNullable()
                         .WithColumn("Status").AsBoolean().NotNullable();
        }
}
