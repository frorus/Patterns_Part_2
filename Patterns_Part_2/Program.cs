using System;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace Patterns_Part_2
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Введите YouTube видео ID или URL: ");
            string videoId = Console.ReadLine();

            while (VideoId.TryParse(videoId) == null)
            {
                Console.WriteLine("ID / URL видео введено некорректно, попробуйте еще раз");
                videoId = Console.ReadLine();
            }

            videoId = VideoId.Parse(videoId);
            Console.WriteLine();

            // создадим отправителя
            var sender = new Sender();

            // создадим получателя
            var receiver = new Receiver(videoId);

            // запуск команды на получение информации о видео
            sender.SetCommand(new GetInfoCommand(receiver));
            await sender.Run();

            // запуск команды на скачивание видео
            sender.SetCommand(new DownloadCommand(receiver));
            await sender.Run();
        }
    }
}
