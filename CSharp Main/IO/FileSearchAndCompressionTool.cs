using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using System.IO.Compression;
using System.IO.Enumeration;
using System.Diagnostics;

namespace IO
{
    enum UserInput
    {
        SearchFile = 1,
        ReadFile = 2,
        CompressionFile = 3,
        ExitFile = 4
    }
    internal static class FileSearchAndCompressionTool
    {
        
        public static async Task MainFunc()
        {
            bool isExit = false;
            string resultPath = "";
            while (!isExit)
            {
                Console.WriteLine("Введите цифру 1-4: ");
                Console.WriteLine("1. Поиск файла");
                Console.WriteLine("2. Просмотр файла");
                Console.WriteLine("3. Сжатие файла");
                Console.WriteLine("4. Выход");
                int userNumber = int.Parse(Console.ReadLine());
                UserInput userInput = (UserInput)userNumber;
                switch (userInput)
                {
                    case UserInput.SearchFile:
                        resultPath = Search();
                        if (!wasFileFound(resultPath)) break;
                        break;
                    case UserInput.ReadFile:
                        if (!wasFileFound(resultPath)) break;
                        await ReadAsync(resultPath);
                        break;
                    case UserInput.CompressionFile:
                        if (!wasFileFound(resultPath)) break;
                        Compression(resultPath);
                        break;
                    case UserInput.ExitFile:
                        isExit = true;
                        break;
                    default:
                        break;
                }
                static bool wasFileFound (string path)
                {
                    if (path == "")
                    {
                        Console.WriteLine("Файл не был найден.");
                        return false;
                    }
                    return true;
                }
            }
        }
        private static string Search()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            List<string> drivesName = new();
            foreach (var drive in drives) { drivesName.Add(drive.Name); }
            Console.Write("Введите название диска: ");
            foreach(var name in drivesName) { Console.Write($"\"{name}\" "); }
            Console.Write("\n");
            Console.WriteLine("Или укажите абсолютный путь до нужной папки (Пример: \"C:\\Games\"): ");
            string dirName = Console.ReadLine();
            Console.WriteLine("Укажите название нужного файла: ");
            string fileName = Console.ReadLine();
            string path = RecursiveSearch(dirName, fileName);
            return path;
        }
        static string RecursiveSearch(string path, string file)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                foreach (string s in files)
                {
                    if (s == path + "\\" + file)
                    {
                        Console.WriteLine($"Полный путь до файла: {path}\\{file}");
                        return $"{path}\\{file}";
                    }
                }
                string[] dirs = Directory.GetDirectories(path);
                foreach (string s in dirs)
                {
                    string result = RecursiveSearch(s, file);
                    if (result != "") return result;
                }
            }
            return "";
        }
        private static async Task ReadAsync(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string text = await reader.ReadToEndAsync();
                Console.Write(text);
            }
            Console.WriteLine();
        }
        private static void Compression(string sourcePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(sourcePath);
            string directoryName = Path.GetDirectoryName(sourcePath);
            string compressedFile = Path.Combine(directoryName, fileName + ".zip");

            // Архивация файла
            ZipFile.CreateFromDirectory(sourcePath, compressedFile);
            Console.WriteLine($"Папка {sourcePath} архивирована в файл {compressedFile}");

            // Распаковка архивированного файла в исходную папку
            ZipFile.ExtractToDirectory(compressedFile, directoryName);
            Console.WriteLine($"Файл {compressedFile} распакован в папку {directoryName}");
        }
    }
}
