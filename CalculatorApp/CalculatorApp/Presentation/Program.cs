using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class VatCalculations
    {
        public decimal WithVAT(decimal sum, decimal percent)
        {
            return Math.Round(sum + sum * percent / 100, 2);
        }

        public decimal WithoutVAT(decimal sum, decimal percent)
        {
            return Math.Round(sum / (1 + percent / 100), 2);
        }
    }

    public class CalcOperations
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            return a / b;
        }

        public double ModuleDivide(double a, double b)
        {
            return a % b;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("This is school project.");
            Console.WriteLine("------CALCULATOR+VAT-------");

            CalcOperations calc = new CalcOperations();
            VatCalculations vat = new VatCalculations();

            while (true)
            {
                Console.WriteLine("Моят калкулатор");
                Console.WriteLine("1 - Калкулатор");
                Console.WriteLine("2 - ДДС калкулатор");
                Console.WriteLine("0 - Изход");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    Console.WriteLine("Въведи пример, например 2+3 или 5*2.");
                    Console.WriteLine("Въведи 0 за връщане.");

                    while (true)
                    {
                        string text = Console.ReadLine();

                        if (text == "0")
                        {
                            break;
                        }

                        try
                        {
                            double a, b;
                            int i;

                            if (text.Contains("+"))
                            {
                                i = text.IndexOf("+");
                                a = double.Parse(text.Substring(0, i));
                                b = double.Parse(text.Substring(i + 1));
                                Console.WriteLine(calc.Add(a, b));
                            }
                            else if (text.Contains("-"))
                            {
                                i = text.IndexOf("-");
                                a = double.Parse(text.Substring(0, i));
                                b = double.Parse(text.Substring(i + 1));
                                Console.WriteLine(calc.Subtract(a, b));
                            }
                            else if (text.Contains("*"))
                            {
                                i = text.IndexOf("*");
                                a = double.Parse(text.Substring(0, i));
                                b = double.Parse(text.Substring(i + 1));
                                Console.WriteLine(calc.Multiply(a, b));
                            }
                            else if (text.Contains("/"))
                            {
                                i = text.IndexOf("/");
                                a = double.Parse(text.Substring(0, i));
                                b = double.Parse(text.Substring(i + 1));

                                if (b != 0)
                                    Console.WriteLine(calc.Divide(a, b));
                                else
                                    Console.WriteLine("Не може да се дели на нула!");
                            }
                            else if (text.Contains("%"))
                            {
                                i = text.IndexOf("%");
                                a = double.Parse(text.Substring(0, i));
                                b = double.Parse(text.Substring(i + 1));

                                if (b != 0)
                                    Console.WriteLine(calc.ModuleDivide(a, b));
                                else
                                    Console.WriteLine("Не може да се дели на нула!");
                            }
                            else
                            {
                                Console.WriteLine("Невалидна операция!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Грешен вход!");
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("1 - Сума с ДДС");
                    Console.WriteLine("2 - Сума без ДДС");

                    int option = int.Parse(Console.ReadLine());

                    Console.WriteLine("Въведи сума:");
                    decimal sum = decimal.Parse(Console.ReadLine());

                    Console.WriteLine("Въведи процент ДДС:");
                    decimal percent = decimal.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        Console.WriteLine("Сума с ДДС: " + vat.WithVAT(sum, percent));
                    }
                    else if (option == 2 && percent > -100)
                    {
                        Console.WriteLine("Сума без ДДС: " + vat.WithoutVAT(sum, percent));
                    }
                    else
                    {
                        Console.WriteLine("Невалиден избор!");
                    }
                }
                else
                {
                    Console.WriteLine("Невалиден избор!");
                }
            }
        }
    }

}
