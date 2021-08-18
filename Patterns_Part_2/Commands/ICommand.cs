using System.Threading.Tasks;

namespace Patterns_Part_2
{
    /// <summary>
    /// Базовый интерфейс команды
    /// </summary>
    public interface ICommand
    {
        public Task Run();
    }
}
