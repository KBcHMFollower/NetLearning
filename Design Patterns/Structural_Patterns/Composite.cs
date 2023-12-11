using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Компонент: Абстрактный класс для файлов и директорий
    public abstract class FileSystemItem
    {
        public string Name { get; }

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract void Display();
    }

    // Лист: Класс представляющий файл
    public class File : FileSystemItem
    {
        public File(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"Файл: {Name}");
        }
    }

    // Композит: Класс представляющий директорию
    public class Directory : FileSystemItem
    {
        private List<FileSystemItem> items = new List<FileSystemItem>();

        public Directory(string name) : base(name) { }

        public void Add(FileSystemItem item)
        {
            items.Add(item);
        }

        public void Remove(FileSystemItem item)
        {
            items.Remove(item);
        }

        public override void Display()
        {
            Console.WriteLine($"Директория: {Name}");

            foreach (var item in items)
            {
                item.Display();
            }
        }
    }
}
