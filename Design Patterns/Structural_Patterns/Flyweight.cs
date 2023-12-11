using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Интерфейс для легковесного объекта
    public interface IImage
    {
        void Display(int x, int y);
    }

    // Конкретный легковес: Реальное представление изображения
    public class RealImage : IImage
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadImageFromDisk();
        }

        private void LoadImageFromDisk()
        {
            Console.WriteLine($"Загрузка изображения: {filename}");
            // Логика загрузки изображения с диска
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Отображение изображения {filename} по координатам ({x}, {y})");
            // Логика отображения изображения
        }
    }

    // Фабрика легковесных объектов
    public class ImageFactory
    {
        private Dictionary<string, IImage> images;

        public ImageFactory()
        {
            images = new Dictionary<string, IImage>();
        }

        public IImage GetImage(string filename)
        {
            if (!images.ContainsKey(filename))
            {
                images[filename] = new RealImage(filename);
            }

            return images[filename];
        }
    }
}
