using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {
            while (true) {
                printMenu();
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: printAllIceCream(); break;
                    case 2: deleteIceCream(choice); break;
                    case 3: sortIceCream(); break;
                    case 4: findIceCream(choice); break;
                    default: return;
                }
            }
        }

        static void printMenu() {
            Console.WriteLine("---МЕНЮ ВЫБОРА----");
            Console.WriteLine("" +
                "1 - Добавить новое мороженое\n" +
                "2 - Удалить мороженое\n" +
                "3 - Отсортировать мороженое по цене\n" +
                "4 - Найти мороженое\n" +
            "");
        }

        static void printAllIceCream() {
            Console.WriteLine("Print all ice cream");
        }

        static void deleteIceCream(int number) {
            Console.WriteLine("Delete ice cream");
        }

        static void findIceCream(int number) {
            Console.WriteLine("Find ice cream");
        }

        static void sortIceCream() {
            Console.WriteLine("Sort Ice cream");
        }
    }
}
