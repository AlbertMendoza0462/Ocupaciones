// See https://aka.ms/new-console-template for more information

int? respuesta = -1;

while (respuesta != 0)
{
    Console.WriteLine("Hello, World!\n");

    Console.WriteLine("Ocupaciones\n");

    Console.WriteLine("0. Salir\n1. Nuevo\n2. Consultar");

try
{
    respuesta = Int32.Parse(Console.ReadLine()??"-1");
}
catch (System.Exception)
{
    respuesta = -1;
}
    Console.WriteLine();

    switch (respuesta)
    {
        case 0: salir(); break;
        case 1: nuevo(); break;
        case 2: consultar(); break;
        default: Console.WriteLine("Respuesta invalida..."); break;
    }
    finalEjecucion();
}

void nuevo()
{
    Ocupacion ocupacion = new Ocupacion();
    Console.Write("Descripcion: ");
    ocupacion.Descripcion = Console.ReadLine();
    Console.Write("Salario (Mayor que 0): ");
    try
    {
        ocupacion.Salario = Int32.Parse(Console.ReadLine()??"0");
    }
    catch (System.Exception)
    {
        ocupacion.Salario = 0;
    }

    if (ocupacion.Salario > 0 && !String.IsNullOrWhiteSpace(ocupacion.Descripcion))
    {
        ocupacion.OcupacionID = 0;

        Contexto contexto = new Contexto();

        contexto.Add(ocupacion);

        contexto.SaveChanges();

        Console.WriteLine("Guardado con exito...");
    }
    else
    {
        Console.WriteLine("Datos invalidos, no se pudo guardar");
    }
}

void consultar()
{
    Contexto contexto = new Contexto();
    List<Ocupacion> ocupaciones = contexto.Ocupaciones.ToList();

    Console.WriteLine("ID\tDescripcion\t\tSalario");
    foreach (Ocupacion ocupacion in ocupaciones)
    {
        Console.WriteLine(ocupacion.OcupacionID + "\t" + ocupacion.Descripcion + "\t\t\t" + ocupacion.Salario);
    }
}

void finalEjecucion()
{
    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
}

void salir()
{
    Console.Clear();
    Console.WriteLine("Gracias!!");
}