using System.Threading.Tasks;

namespace Patterns_Part_2
{
    /// <summary>
    /// Реализация команды получения информации о видео
    /// </summary>
    public class GetInfoCommand : ICommand
    {
        Receiver receiver;

        public GetInfoCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public async Task Run()
        {
            await receiver.GetInfo();
        }
    }
}
