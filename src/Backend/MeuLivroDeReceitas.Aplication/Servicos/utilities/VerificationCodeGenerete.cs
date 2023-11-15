
namespace MeuLivroDeReceitas.Aplication.Servicos.utilities;

public  static class VerificationCodeGenerete
{
    public static string Generate()
    {
        Random random = new Random();

        // Gera quatro números aleatórios entre 1 e 100
        int numero1 = random.Next(1, 9);
        int numero2 = random.Next(1, 9);
        int numero3 = random.Next(1, 9);
        int numero4 = random.Next(1, 9);

        var resultado= $"{numero1}{numero3}{numero3}{numero4}";

        return resultado;

    }
}
