// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Runtime.CompilerServices;

string? path;

Console.WriteLine("¡Bienvenido!");

do
{
    Console.WriteLine("Ingrese un path de un directorio valido:");
    path = Console.ReadLine();


    if (!Directory.Exists(path))
    {
        Console.WriteLine("El directorio no existe :[");
        Console.WriteLine("Ingrese un path valido nuevamente");
    }

} while (!Directory.Exists(path));

Console.WriteLine("El directorio si existe :D");

//Inicializamos nuestros directorio, carpetas y archivos
DirectoryInfo ruta = new DirectoryInfo(path);
FileInfo[] archivos;
DirectoryInfo[] carpetas;

if (ruta.GetDirectories().Length != 0)
{
    carpetas = ruta.GetDirectories();
    foreach (DirectoryInfo nombreCarpetas in carpetas) 
    {
        Console.WriteLine($"Carpeta {nombreCarpetas}");
    }
}else
{
    Console.WriteLine("El directorio no tiene carpetas :[");
}

List<string> LineasTexto = new List<string>();
LineasTexto.Add("Nombre;Tamanio(KB)");

if (ruta.GetFiles().Length != 0)
{
    archivos = ruta.GetFiles();
    foreach (FileInfo nombreArchivos in archivos)
    {
        double tamanioKB = nombreArchivos.Length / 1024.0;
        Console.WriteLine($"Archivo {nombreArchivos} - Tamanio {tamanioKB:F2} KB");
        LineasTexto.Add($"{nombreArchivos.Name};{tamanioKB:F2}");
    }
}
else
{
    Console.WriteLine("El directorio no tiene archivos :[");
}

// Guardar la lista en un archivo CSV
string csvPath = Path.Combine(path, "archivoss.csv");
File.WriteAllLines(csvPath, LineasTexto);
Console.WriteLine($"Archivo CSV creado en: {csvPath}");

