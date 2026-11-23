using System.Globalization;

public static class MenuArray
{
    private static double[] datos = Array.Empty<double>();

    public static void Ejecutar()
    {
        bool volver = false;

        while (!volver)
        {
            Console.WriteLine();
            Console.WriteLine("=== PROYECTO ARRAY ===");
            Console.WriteLine("1. Introducir array");
            Console.WriteLine("2. Calcular máximo");
            Console.WriteLine("3. Calcular mínimo");
            Console.WriteLine("4. Calcular media");
            Console.WriteLine("5. Calcular mediana");
            Console.WriteLine("6. Ordenar de menor a mayor");
            Console.WriteLine("0. Volver");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1": datos = LeerArray(); break;
                case "2": if (HayDatos()) Console.WriteLine($"Máximo: {Fmt(Maximo(datos))}"); break;
                case "3": if (HayDatos()) Console.WriteLine($"Mínimo: {Fmt(Minimo(datos))}"); break;
                case "4": if (HayDatos()) Console.WriteLine($"Media: {Fmt(Media(datos))}"); break;
                case "5": if (HayDatos()) Console.WriteLine($"Mediana: {Fmt(Mediana(datos))}"); break;
                case "6": if (HayDatos()) Console.WriteLine($"Ordenado: {Formato(Ordenar(datos))}"); break;
                case "0": volver = true; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    private static double[] LeerArray()
    {
        Console.Write("Introduce los números separados por espacios: ");
        string? linea = Console.ReadLine();
        string[] partes = (linea ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] resultado = new double[partes.Length];

        for (int i = 0; i < partes.Length; i++)
        {
            if (!double.TryParse(partes[i].Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out resultado[i]))
            {
                Console.WriteLine($"'{partes[i]}' no es un número válido. Array no guardado.");
                return datos;
            }
        }

        Console.WriteLine($"Array guardado: {Formato(resultado)}");
        return resultado;
    }

    private static bool HayDatos()
    {
        if (datos.Length == 0)
        {
            Console.WriteLine("Primero introduce un array (opción 1).");
            return false;
        }
        return true;
    }

    public static double Maximo(double[] a)
    {
        double max = a[0];
        foreach (double n in a)
            if (n > max) max = n;
        return max;
    }

    public static double Minimo(double[] a)
    {
        double min = a[0];
        foreach (double n in a)
            if (n < min) min = n;
        return min;
    }

    public static double Media(double[] a)
    {
        double suma = 0;
        foreach (double n in a) suma += n;
        return suma / a.Length;
    }

    public static double[] Ordenar(double[] a)
    {
        double[] copia = (double[])a.Clone();
        Array.Sort(copia);
        return copia;
    }

    public static double Mediana(double[] a)
    {
        double[] o = Ordenar(a);
        int mitad = o.Length / 2;
        if (o.Length % 2 == 1) return o[mitad];
        return (o[mitad - 1] + o[mitad]) / 2;
    }

    private static string Fmt(double n) => n.ToString("0.##", CultureInfo.InvariantCulture);

    private static string Formato(double[] a) => string.Join(", ", a.Select(Fmt));
}
