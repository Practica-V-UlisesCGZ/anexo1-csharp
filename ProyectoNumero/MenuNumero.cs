public static class MenuNumero
{
    public static void Ejecutar()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine();
            Console.WriteLine("=== PROYECTO NÚMERO ===");
            Console.WriteLine("1. Comprobar si es primo");
            Console.WriteLine("2. Calcular el factorial");
            Console.WriteLine("3. Convertir segundos a horas, minutos y segundos");
            Console.WriteLine("0. Volver");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1": OpcionPrimo(); break;
                case "2": OpcionFactorial(); break;
                case "3": OpcionSegundos(); break;
                case "0": volver = true; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    private static bool LeerEntero(string mensaje, out long numero)
    {
        Console.Write(mensaje);
        if (long.TryParse(Console.ReadLine(), out numero)) return true;
        Console.WriteLine("Número no válido.");
        return false;
    }

    private static void OpcionPrimo()
    {
        if (!LeerEntero("Introduce un número entero: ", out long n)) return;
        Console.WriteLine(EsPrimo(n) ? $"{n} es primo." : $"{n} no es primo.");
    }

    private static void OpcionFactorial()
    {
        if (!LeerEntero("Introduce un número entero (0 a 100): ", out long n)) return;
        if (n < 0 || n > 100)
        {
            Console.WriteLine("El número debe estar entre 0 y 100.");
            return;
        }
        Console.WriteLine($"{n}! = {Factorial((int)n)}");
    }

    private static void OpcionSegundos()
    {
        if (!LeerEntero("Introduce los segundos: ", out long s)) return;
        if (s < 0)
        {
            Console.WriteLine("Los segundos no pueden ser negativos.");
            return;
        }
        var (h, m, seg) = ConvertirSegundos(s);
        Console.WriteLine($"{s} segundos = {h} h, {m} min, {seg} s");
    }

    public static bool EsPrimo(long n)
    {
        if (n < 2) return false;
        for (long i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    public static System.Numerics.BigInteger Factorial(int n)
    {
        System.Numerics.BigInteger resultado = 1;
        for (int i = 2; i <= n; i++)
            resultado *= i;
        return resultado;
    }

    public static (long horas, long minutos, long segundos) ConvertirSegundos(long total)
    {
        return (total / 3600, (total % 3600) / 60, total % 60);
    }
}
