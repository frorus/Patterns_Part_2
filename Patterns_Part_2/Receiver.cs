using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Patterns_Part_2
{
    /// <summary>
    /// Адресат команды
    /// </summary>
    public class Receiver
    {
        YoutubeClient youtube;
        string idForVideo;

        public Receiver(string videoId)
        {
            youtube = new YoutubeClient();
            idForVideo = videoId;
        }

        public async Task GetInfo()
        {
            var video = await youtube.Videos.GetAsync(idForVideo);

            Console.WriteLine($"Название: {video.Title}");
            Console.WriteLine($"Автор: {video.Author}");
            Console.WriteLine($"Продолжительность: {video.Duration}");
            Console.WriteLine($"Описание: {video.Description}\n");
        }

        public async Task Download()
        {
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(idForVideo);
            var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality();
            if (streamInfo is null)
            {
                Console.Error.WriteLine("У видео нет смешанных потоков.");
            }

            // Скачивание видео
            Console.Write($"Скачивание видео: {streamInfo.VideoQuality.Label} / {streamInfo.Container.Name}...");

            var fileName = $"{idForVideo}.{streamInfo.Container.Name}";

            using (var progress = new InlineProgress()) // отображает прогресс в консоли
                await youtube.Videos.Streams.DownloadAsync(streamInfo, fileName, progress);

            Console.WriteLine($"Видео сохранено как '{fileName}'");
        }
    }
}
