using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Patterns
{
    // Существующий класс с несовместимым интерфейсом
    public class LegacyFileReader
    {
        public void ReadFile(string fileName)
        {
            Console.WriteLine($"Чтение файла: {fileName}");
            // Логика чтения файла
        }
    }

    // Целевой интерфейс, ожидаемый новой системой
    public interface INewFileReader
    {
        void OpenFile(string fileName);
    }

    // Адаптер, преобразующий интерфейс LegacyFileReader в INewFileReader
    public class LegacyFileReaderAdapter : INewFileReader
    {
        private LegacyFileReader legacyFileReader;

        public LegacyFileReaderAdapter(LegacyFileReader legacyFileReader)
        {
            this.legacyFileReader = legacyFileReader;
        }

        public void OpenFile(string fileName)
        {
            legacyFileReader.ReadFile(fileName);
        }
    }

    // Клиентский код, использующий новую систему
    public class NewSystemClient
    {
        private INewFileReader newFileReader;

        public NewSystemClient(INewFileReader reader)
        {
            newFileReader = reader;
        }

        public void PerformReadOperation(string fileName)
        {
            newFileReader.OpenFile(fileName);
        }
    }
}
