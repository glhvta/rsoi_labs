using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication {
    class Program {
        static string pathToFile = "D:\\Университет\\3 курс\\6 семестр\\РСОИ\\rsoi_labs\\lab_5 - Консольное приложение C#\\iceCreamsData.txt";
        static int iceCreamsNumber = 1;

        static void Main(string[] args) {
            while (true) {
                printMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: addIceCream(); break;
                    case 2: deleteIceCream(); break;
                    case 3: sortIceCream(); break;
                    case 4: findIceCream(); break;
                    case 5: changeIceCreamCost(); break;
                    case 6: printAllIceCream(); break;
                    default: return;
                }
            }
        }

        static void printMenu() {
            Console.WriteLine(
                "\n---МЕНЮ ВЫБОРА----\n" +
                "1 - Добавить новое мороженое\n" +
                "2 - Удалить мороженое\n" +
                "3 - Отсортировать мороженое по цене\n" +
                "4 - Найти мороженое\n" +
                "5 - Изменить стоимость мороженого\n" + 
                "6 - Вывести на экран все записи\n"
            );
        }
        static void addIceCream() {
            StreamWriter sw = null;  

            try {
                Console.WriteLine("Введите название мороженого:  ");
                string name = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Введите стоимость мороженого:  ");
                double cost = Convert.ToDouble(Console.ReadLine());

                sw = new StreamWriter(pathToFile, true, System.Text.Encoding.Default);
                sw.WriteLine(iceCreamsNumber++ + ": " + name + "  $" + cost);
                Console.WriteLine("Данные были добавлены успешно!");
            }
            catch {
                Console.WriteLine("Ошибка при записи в файл:(");
            }
            finally {
                sw.Close();
            }
        }

        static void rewriteIceCreamData(string data) {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(pathToFile, false, System.Text.Encoding.Default);
                sw.WriteLine(data);
                Console.WriteLine("Данные были изменены успешно!");
            }
            catch
            {
                Console.WriteLine("Ошибка при перезаписи файла:(");
            }
            finally
            {
                sw.Close();
            }
        }

        static string getIceCreamFromFile() {
            StreamReader sr = null;
            string data = "";

            try {
                sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
                data = sr.ReadToEnd();

            }
            catch {
                Console.WriteLine("Ошибка при чтении");
            }
            finally {
                sr.Close();
            }

            return data;
        }

        static IEnumerable<string> getIceCreamList()
        {
            string iceCreamString = getIceCreamFromFile();

            return iceCreamString.Split(new[] { '\r', '\n' }).Where(line => line != ""); ;
        }

        static void printAllIceCream() {
            Console.WriteLine("Мороженое: \n" + getIceCreamFromFile());
        }

        static void deleteIceCream() {
            Console.WriteLine("Введите номер мороженого для удаления:  ");
            char number = Convert.ToChar(Console.ReadLine());

            IEnumerable<string> newIceCreamList = getIceCreamList()
                .Where(line => line[0] != number);

            rewriteIceCreamData(String.Join("\n", newIceCreamList));
        }

        static void findIceCream() {
            Console.WriteLine("Введите мороженое для поиска:  ");
            string iceCream = Console.ReadLine();

            IEnumerable<string> iceCreamList = getIceCreamList();

            foreach (string line in iceCreamList)
            {
                if (line.Contains(iceCream))
                {
                    Console.WriteLine(line);
                }

            }
        }

        static int getCost (string data) {
            int i = data.IndexOf('$');
            string cost = data.Substring(i + 1);
            return Convert.ToInt32(cost);
        }

        static void sortIceCream() {
            string[] iceCreams = getIceCreamList().ToArray<string>();

            string temp;
            for (int i = 0; i < iceCreams.Length - 1; i++)
            {
                for (int j = i + 1; j < iceCreams.Length; j++)
                {    
                    int cost1 = getCost(iceCreams[i]);
                    int cost2 = getCost(iceCreams[j]);

                    if (cost1 > cost2)
                    {
                        temp = iceCreams[i];
                        iceCreams[i] = iceCreams[j];
                        iceCreams[j] = temp;
                    }
                }
            }

            rewriteIceCreamData(String.Join("\n", iceCreams));
        }

        static void changeIceCreamCost() {
            Console.WriteLine("Введите номер мороженого для изменения:  ");
            char number = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Введите новую стоимость:  ");
            string newCost = Console.ReadLine();

            string[] iceCreams = getIceCreamList().ToArray<string>();

            for (int i = 0; i < iceCreams.Length; i++ )
            {
                if (iceCreams[i][0] == number)
                {
                    string prevCost = Convert.ToString(getCost(iceCreams[i]));
                    iceCreams[i] = iceCreams[i].Replace(prevCost, newCost);
                }
            }

            rewriteIceCreamData(String.Join("\n", iceCreams));
        }

    }
}
