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
            Console.WriteLine("4. Mostrar los 15 primeros números de Pell");
            Console.WriteLine("5. Comprobar si es un número de Armstrong");
            Console.WriteLine("6. Comprobar si tiene todos sus dígitos diferentes");
            Console.WriteLine("0. Volver");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1": OpcionPrimo(); break;
                case "2": OpcionFactorial(); break;
                case "3": OpcionSegundos(); break;
                case "4": OpcionPell(); break;
                case "5": OpcionArmstrong(); break;
                case "6": OpcionDigitos(); break;
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

    private static void OpcionPell()
    {
        Console.WriteLine("Los 15 primeros números de Pell:");
        Console.WriteLine(string.Join(", ", Pell(15)));
    }

    private static void OpcionArmstrong()
    {
        if (!LeerEntero("Introduce un número entero: ", out long n)) return;
        Console.WriteLine(EsArmstrong(n) ? $"{n} es un número de Armstrong." : $"{n} no es un número de Armstrong.");
    }

    private static void OpcionDigitos()
    {
        if (!LeerEntero("Introduce un número entero: ", out long n)) return;
        Console.WriteLine(DigitosDiferentes(n) ? $"{n} tiene todos sus dígitos diferentes." : $"{n} tiene dígitos repetidos.");
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

    public static long[] Pell(int cantidad)
    {
        long[] serie = new long[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            if (i == 0) serie[i] = 0;
            else if (i == 1) serie[i] = 1;
            else serie[i] = 2 * serie[i - 1] + serie[i - 2];
        }
        return serie;
    }

    public static bool EsArmstrong(long n)
    {
        if (n < 0) return false;
        string digitos = n.ToString();
        int cantidad = digitos.Length;
        long suma = 0;
        foreach (char c in digitos)
        {
            long potencia = 1;
            for (int i = 0; i < cantidad; i++)
                potencia *= c - '0';
            suma += potencia;
        }
        return suma == n;
    }

    public static bool DigitosDiferentes(long n)
    {
        string digitos = Math.Abs(n).ToString();
        return digitos.Distinct().Count() == digitos.Length;
    }
}
