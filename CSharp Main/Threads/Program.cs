using System.Runtime.InteropServices;
using System.Threading;

namespace Threads;
internal class Program
{
    static void Main(string[] args)
    {
        const int windowheight = 40, windowwidth = 80;
        Console.SetWindowSize(windowwidth, windowheight);
        Random random = new((int)DateTime.Now.Microsecond);
        for (int i = 0; i < 20; ++i)
        {
            Matrix matrix;
            matrix = new Matrix((int)random.Next(0, windowwidth));
            new Thread(matrix.Print).Start();
        }
    }
}