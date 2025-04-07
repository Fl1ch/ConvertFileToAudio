using System;
using System.IO;
using System.Linq;

namespace ConvertFileToAudio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(" ");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine("Директория для файлов создана");

            while (true)
            {
                Console.WriteLine("Переместите все файлы в консоль:");

                string input = Console.ReadLine();

                string[] filePaths = input.Split('"')
                                          .Where(part => !string.IsNullOrWhiteSpace(part) && part != " ")
                                          .ToArray();

                foreach (string file in filePaths)
                {
                    string filePath = file.Trim();
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"Файл не найден: {filePath}");
                        continue;
                    }

                    string convertedFileName = Path.GetFileNameWithoutExtension(filePath);
                    Console.WriteLine($"Идет обработка файла: {convertedFileName}");

                    cs_ffmpeg_mp3_converter.FFMpeg.Convert2Mp3(filePath, $"FileConverted/{convertedFileName}.mp3");

                    Console.WriteLine($"Работа с файлом {convertedFileName} завершена!");
                }

                Console.WriteLine("Обработка всех переданных файлов завершена!");
            }
        }
    }
}
