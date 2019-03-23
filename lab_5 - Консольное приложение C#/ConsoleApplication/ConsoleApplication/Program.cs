using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {
            pritnMenu();
            Console.ReadKey();
        }

        static void pritnMenu() {
            Console.WriteLine("---МЕНЮ ВЫБОРА----");
            Console.WriteLine("" +
                "1 - Добавить новое мороженое\n" +
                "2 - Удалить мороженое\n" +
                "3 - Отсортировать мороженое по цене\n" +
                "4 - Найти мороженое\n" +
            "");
        }
    }
}
