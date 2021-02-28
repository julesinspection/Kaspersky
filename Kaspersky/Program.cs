using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kaspersky
{

    public class FileProcessor {
        public string extension { get; private set; } //формат файла
        public string fileFullName { get; private set; } //имя файла + формат
        public string filePath { get; private set; } //путь к файлу

        //Directory.GetCurrentDirectory() возвращает путь к папке ..\Kaspersky\Kaspersky\bin\Debug\netcoreapp3.1
        //чтобы перейти к папке с проектом Visual Studio нам необходимо подняться на 4 каталога вверх
        public string GetMyPath() => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

        public void ProcessFile(string fileName)
        {
            int i, numberOfFile; //перечислитель, номер файла который выбирает пользователь в консоли
            //вычисляем путь к корневой папке проекта
            string path = GetMyPath();

            //поиск файлов с таким именем любого формата по заданному пути
            string[] files = Directory.GetFiles(path, fileName + ".*", SearchOption.AllDirectories);

            //вывод в консоль всех файлов и их путей с данным именем любого формата
            for (i = 0; i < files.Length; i++) {
                Console.WriteLine("{0}>  {1}", i + 1, files[i]);
            }

            try {
                //ввод номера файла из консоли
                Console.WriteLine("Выберите файл> ");
                numberOfFile = Convert.ToInt32(Console.ReadLine()) - 1;

                //вычиление формата файла
                extension = files[numberOfFile].Substring(files[numberOfFile].LastIndexOf('.'));

                //вычисление полного имени и пути к файлу
                fileFullName = fileName + extension;
                filePath = files[numberOfFile].Replace(fileFullName, "");

                //здесь мы можем проводить любые операции с файлом
                using StreamWriter file = new StreamWriter(filePath + fileFullName, true, Encoding.Default);
                file.WriteLine("hello");//например допишем строку hello
            }
            catch { //исключение на случай если пользователь ввел номер несуществующего решения
                Console.WriteLine("Неверно введенные данные");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();

            FileProcessor f = new FileProcessor();
            f.ProcessFile(fileName);
            //здесь мы можем проводить любые операции с файлом
            Console.ReadKey();
        }
    }
}