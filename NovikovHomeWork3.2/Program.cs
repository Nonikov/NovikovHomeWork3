using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NovikovHomeWork3._2
{
    //Test class
    class Man
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    #region override Tostring()
    class MyClass1
    {
    }

    class MyClass2
    {
        public override string ToString()
        {
            return "Changed the MyClass2 ToString()";
        }
    }

    #endregion

    class Test
    {
        public void DemoFormat()
        {
            #region Format flags

            double number = 152.72;

            Console.OutputEncoding = Encoding.UTF8; // For Ukraine currency

            Console.WriteLine(String.Format("{0:C}", number));

            Console.WriteLine($"{number.ToString("C", new CultureInfo("en-US"))}");

            Console.WriteLine(String.Format("{0:C2}", number));

            Console.WriteLine($"{number:C2}");
            Console.WriteLine();

            Console.WriteLine("C format: {0:C}", 99.9);     // Money 
            Console.WriteLine("F format: {0:##}", 99.935);  // Fixed accuracy 
            Console.WriteLine("N format: {0:N}", 99999);    // Standart numeric formatting
            Console.WriteLine("X format: {0:X}", 255);      // HEX 
            Console.WriteLine("D format: {0:D}", 0xFF);     // DEC 
            Console.WriteLine("E format: {0:E}", 9999);     // Exponential 
            Console.WriteLine("G format: {0:G}", 99.9);     // Common 
            Console.WriteLine("P format: {0:P}", 99.9);     // Percent
            Console.WriteLine();

            #endregion

            #region Culture

            // Amount for a formatted display
            decimal money = 12347.257m;
            StringBuilder result = new StringBuilder();

            // Three available culture
            var american = new CultureInfo("en-US");
            var germany = new CultureInfo("de-DE");
            var russian = new CultureInfo("ru-RU");
            
            // Three string formmatting fot the necessary culture
            string localMoney = money.ToString("C", american);
            result.Append(String.Format("Деньги США: {0}", localMoney));

            localMoney = money.ToString("C", germany);
            result.AppendFormat("\nДеньги Германии: {0}", localMoney);

            result.AppendFormat($"\nДеньги России: {money.ToString("C", russian)}");

            Console.WriteLine(result);
            Console.WriteLine();

            #endregion

            #region Other formatting

            Man man = new Man { Name = "Ivan", Age = 25 }; // Man instantiation

            Console.WriteLine(String.Format("Name: {0}  Age: {1}", man.Name, man.Age));
            Console.WriteLine($"Name: {man.Name} Age: {man.Age}");
            Console.WriteLine();

            Console.WriteLine($"Имя: {man.Name,-5} Возраст: {man.Age}"); // Spaces after
            Console.WriteLine($"Имя: {man.Name,5} Возраст: {man.Age}"); // Spaces before
            Console.WriteLine();

            int x = 8, y = 7;
            Console.WriteLine($"{x} + {y} = {x + y:F4}");
            Console.WriteLine();

            long numb = 32836543217;
            // Telephone number formatting
            Console.WriteLine(numb.ToString("+# (###) ###-##-##"));
            Console.WriteLine($"{numb:+# (###) ### ## ##}");
            Console.WriteLine();

            #endregion

            #region ToString() overriding
            var class1 = new MyClass1();
            var class2 = new MyClass2();

            Console.WriteLine($"{class1}");
            Console.WriteLine($"{class2}");
            
            #endregion
        }
    }
    class Program
        {

        
        static void Main(string[] args)
        {
            new Test().DemoFormat();

            Console.ReadLine();
        }
    }
}
