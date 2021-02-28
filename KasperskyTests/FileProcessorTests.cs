using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kaspersky;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaspersky.Tests {
    [TestClass()]
    public class FileProcessorTests {
        [TestMethod()]
        //тест проверяет правильно ли программа вычисляет путь к корневому каталогу проекта
        public void GetMyPathTest()
        {
            string MyPath = @"C:\Users\Григорий\source\repos\Kaspersky"; //вручную вводим путь
            FileProcessor p = new FileProcessor();
            Assert.AreEqual(MyPath, p.GetMyPath()); //сравниваем с результатом работы метода GetMyPath
        }
    }
}