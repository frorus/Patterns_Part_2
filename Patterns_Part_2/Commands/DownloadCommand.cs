using System.Threading.Tasks;

namespace Patterns_Part_2
{
    /// <summary>
    /// Реализация команды скачивания
    /// </summary>
    class DownloadCommand : ICommand
    {
        Receiver receiver;

        public DownloadCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public async Task Run()
        {
            await receiver.Download();
        }
    }
}
