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

if (ruta.GetFiles().Length != 0)
{
    archivos = ruta.GetFiles();
    foreach (FileInfo nombreArchivos in archivos)
    {
        Console.WriteLine($"Archivo {nombreArchivos} - Tamanio {nombreArchivos.Length/1024.0:F2} KB");
    }
}
else
{
    Console.WriteLine("El directorio no tiene archivos :[");
}




