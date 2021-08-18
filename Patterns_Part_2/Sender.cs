using System.Threading.Tasks;

namespace Patterns_Part_2
{
    /// <summary>
    /// Отправитель команды
    /// </summary>
    public class Sender
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Выполнить
        public async Task Run()
        {
            await _command.Run();
        }
    }
}
