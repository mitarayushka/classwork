using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //проект => нагет пакеты

namespace ConsoleApp1
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _reviews;

        public string Name => _name;
        public int Duration => _duration;
        public int[] Reviews => _reviews;

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _reviews = new int[0];
        }
        public void Add(int num)
        {
            Array.Resize(ref _reviews, num);
            _reviews[_reviews.Length - 1] = num;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Movie movie1 = new Movie("Harry Potter Part 1", 102);
            movie1.Add(5);
            movie1.Add(4);

            var temp = new
            {
                MovieType = movie1.GetType().Name,
                movie1.Name,
                movie1.Duration,
                movie1.Reviews
            };

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "Test", "example.json");

            //десериализация
            string content = File.ReadAllText(filePath);
            var newJson = JsonConvert.SerializeObject(temp);

            //Movie movie2 = new Movie(newJson.Name)

            //получение путей к папке

            //абсолютный путь

            //относительный путь (relative  path) : dataset => "data.txt" 
                            //это получение пути к рабочему столу:
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //Desktop, MyDocuments, Applications, Favorites etc.
            //string filePath = Path.Combine(folderPath, "example.txt"); //<= путь до самого файла

            //Console.WriteLine(folderPath);
            Console.WriteLine(filePath);

            string folderPath1 = Path.Combine(folderPath, "Test");
            string filePath1 = Path.Combine(folderPath1, "example.txt");

            //if (File.Exists(filePath))
            //{
            //    Console.WriteLine("файл существует!");
            //}
            //else
            //{
            //    Console.WriteLine("файла не существует!");
            //    File.Create(filePath).Close();
            //    Console.WriteLine("файл создан!");
            //}

            string folderPath1Check = Path.GetDirectoryName(filePath1);
            string fileNameCheck = Path.GetFileName(filePath1);
            string fileExtCheck = Path.GetExtension(filePath1);

            if (!Directory.Exists(folderPath1))
            {
                Console.WriteLine("есть папка!");
            }
            else
            {
                Console.WriteLine("нет папки!");
                Directory.CreateDirectory(folderPath1);
            }

            File.WriteAllText(filePath, "прив");
            File.WriteAllLines(filePath, new string[] { "сегодня", "очень", "холодно" });
            //записывает в файл строку
            //если файла нет => создает и вписывает
            //если файл был => перезаписывает содержимое (удаляет старое и пишет новое)

            File.AppendAllText(filePath, "ом мани падме хум");
            File.AppendAllLines(filePath, new string[] { "менд", "цуhаааар"});

            //string content = File.ReadAllText(filePath);
            //string[] lines = File.ReadAllLines(filePath);


            //Console.WriteLine(content);
            //Console.WriteLine(lines);

            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}


            //File.Delete(filePath);
        }

        private bool CompareMovies(Movie m1, Movie m2)
        {
            if (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Reviews.Length != m2.Reviews.Length) return false;
            for (int i = 0; i < m1.Reviews.Length; i++)
            {
                if (m1.Reviews[i] !=  m2.Reviews[i]) return false;
            }
            return true;
        }
    }
}
