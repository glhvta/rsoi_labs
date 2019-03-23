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
                    case 2: deleteIceCream(choice); break;
                    case 3: sortIceCream(); break;
                    case 4: findIceCream(); break;
                    case 5: printAllIceCream(); break;
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
                "5 - Вывести на экран все записи\n"
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
                sw.WriteLine(iceCreamsNumber++ + ": " + name + "  " + cost);
                Console.WriteLine("Данные были добавлены успешно!");
            }
            catch {
                Console.WriteLine("Ошибка при записи в файл:(");
            }
            finally {
                sw.Close();
            }
        }

        static void printAllIceCream() {
            StreamReader sr = null;
            try {
                sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
                Console.WriteLine("Мороженое: \n" + sr.ReadToEnd());
            }
            catch {
                Console.WriteLine("Ошибка при чтении");
            }
            finally {
                sr.Close();
            }
        }

        static void deleteIceCream(int number) {
            Console.WriteLine("Delete ice cream");
        }

        static void findIceCream() {
            StreamReader sr = null;

            Console.WriteLine("Введите мороженое для поиска:  ");
            string iceCream = Console.ReadLine();

            try {
                sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(iceCream)) {
                        Console.WriteLine(line);
                    }
                }
            } catch {
                Console.WriteLine("Ошибка при чтении");
            } finally {
                sr.Close();
            }
        }

        static void sortIceCream() {
            Console.WriteLine("Sort Ice cream");
        }
    }
}
