using System;
using System.Collections.Generic;

namespace MultimediaLibrary
{
    class MediaFile
    {
        public string FileName { get; set; }

        public MediaFile(string fileName)
        {
            FileName = fileName;
        }

        public virtual void Play()
        {
            Console.WriteLine($"Відтворюю медіафайл: {FileName}");
        }
    }

    interface IDownloadable
    {
        void Download(string path);
    }

    interface IStreamable : IDownloadable
    {
        void Stream();
    }

    class AudioFile : MediaFile
    {
        public AudioFile(string fileName) : base(fileName) { }

        public override void Play()
        {
            Console.WriteLine($"Відтворюю аудіо: {FileName}");
        }
    }

    class VideoFile : MediaFile, IStreamable
    {
        public VideoFile(string fileName) : base(fileName) { }

        public override void Play()
        {
            Console.WriteLine($"Відтворюю відео: {FileName}");
        }

        public void Download(string path)
        {
            Console.WriteLine($"Завантажую відео '{FileName}' у {path}");
        }

        public void Stream()
        {
            Console.WriteLine($"Стрімлю відео: {FileName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<MediaFile> mediaFiles = new List<MediaFile>
            {
                new AudioFile("song.mp3"),
                new VideoFile("movie.mp4"),
                new AudioFile("podcast.mp3"),
                new VideoFile("lecture.mp4")
            };

            foreach (var media in mediaFiles)
            {
                media.Play();

                if (media is IStreamable streamable)
                {
                    streamable.Download("C:/Downloads");
                    streamable.Stream();
                }

                Console.WriteLine();
            }
        }
    }
}
