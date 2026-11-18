bool salir = false;

while (!salir)
{
    Console.WriteLine();
    Console.WriteLine("=== MENÚ GENERAL ===");
    Console.WriteLine("1. Array");
    Console.WriteLine("2. Número");
    Console.WriteLine("3. String");
    Console.WriteLine("4. Decimales");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");

    switch (Console.ReadLine())
    {
        case "1": MenuArray.Ejecutar(); break;
        case "2": MenuNumero.Ejecutar(); break;
        case "3": MenuString.Ejecutar(); break;
        case "4": MenuDecimales.Ejecutar(); break;
        case "0": salir = true; break;
        default: Console.WriteLine("Opción no válida."); break;
    }
}
