using System;

namespace Patterns_Part_2
{
    /// <summary>
    /// Класс для отображения шкалы прогресса закачки видео
    /// </summary>
    internal class InlineProgress : IProgress<double>, IDisposable
    {
        private readonly int _posX;
        private readonly int _posY;

        public InlineProgress()
        {
            _posX = Console.CursorLeft;
            _posY = Console.CursorTop;
        }

        public void Report(double progress)
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.WriteLine($"{progress:P1}");
        }

        public void Dispose()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.WriteLine("Готово!");
        }
    }
}
