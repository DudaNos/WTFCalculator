using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Calculator!");
            new Calculator().Calc("1+1");
            Console.ReadLine();
        }
    }

    public class Calculator
    {
        public Calculator()
        {

        }

        public void Calc(string txt)
        {
            List<double> numbers = new List<double>();  //list of all the numbers in the calculation
            // WTF: [Naming] calculator for operators
            List<char> calc = new List<char>();        //List of all the operators in the calculation

            //Alle zulässigen Operatoren
            // WTF: wrong name for contants
            char[] code = new char[4];
            code[0] = '-';
            code[1] = '+';
            code[2] = '*';
            code[3] = '/';

            txt = txt.Replace(" ", String.Empty);

            for (int i = 0; i < txt.Length;)
            {
                Char c = txt[i];


                switch (c)
                {
                    case '/':
                        // WTF: Reduntant if statement and complicated method calls
                        if (txt.Substring(i, 1) != "/")
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOf('/', i) - i)));
                        }
                        // WTF: Incrementing iterator inside the for loop
                        i = txt.IndexOf('/', i) + 1;
                        calc.Add('/');
                        break;
                    case '*':
                        if (txt.Substring(i, 1) != "*")
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOf('*', i) - i)));
                        }
                        i = txt.IndexOf('*', i) + 1;
                        calc.Add('*');
                        break;
                    case '+':
                        if (txt.Substring(i, 1) != "+")
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOf('+', i) - i)));
                        }
                        i = txt.IndexOf('+', i) + 1;
                        calc.Add('+');
                        break;
                    case '-':
                        if (txt.Substring(i, 1)[0] == '-')    //check the first char is a '-', else the number before has to be saved
                        {
                            if (numbers.Count - calc.Count == 0)   //is 0, if '-' a "vorzeichen"
                            {
                                if (txt.IndexOfAny(code, i + 1) < 0) //for the number of chars, which has to be read
                                {
                                    numbers.Add(Convert.ToDouble(txt.Substring(i)));
                                    i = txt.Length;
                                }
                                else
                                {
                                    numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOfAny(code, i + 1) - i)));
                                    i = txt.IndexOfAny(code, i + 1);
                                }
                            }
                            else //
                            {
                                calc.Add('-');
                                i++;
                                if (txt.IndexOfAny(code, i + 1) < 0) //for the number of chars, which has to be read
                                {
                                    numbers.Add(Convert.ToDouble(txt.Substring(i)));
                                    i = txt.Length;
                                }
                                else
                                {
                                    numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOfAny(code, i + 1) - i)));
                                    i = txt.IndexOfAny(code, i + 1);
                                }

                            }
                        }
                        else  //if '-' isn't a "Vorzeichen" and a number is before the minusoperator
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOf('-') - i)));
                            i = txt.IndexOf('-') + 1;
                            calc.Add('-');
                        }
                        break;
                    default:
                        if (txt.IndexOfAny(code, i + 1) < 0) //for the number of chars, which has to be read
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i)));
                            i = txt.Length;
                        }
                        else
                        {
                            numbers.Add(Convert.ToDouble(txt.Substring(i, txt.IndexOfAny(code, i + 1) - i)));
                            i = txt.IndexOfAny(code, i + 1);
                        }
                        break;
                }
            }

            double result = 0;
            result = numbers[0];


            try
            {
                //if (calculation != String.Empty)
                //    numbers.Add(Convert.ToDouble(calculation.Substring(0)));

                numbers.Remove(result);

                foreach (Char c in calc)
                {
                    switch (c)
                    {
                        case '/':
                            result = result / numbers[0];
                            numbers.Remove(numbers[0]);
                            break;
                        case '*':
                            result = result * numbers[0];
                            numbers.Remove(numbers[0]);
                            break;
                        case '+':
                            result = result + numbers[0];
                            numbers.Remove(numbers[0]);
                            break;
                        case '-':
                            result = result - numbers[0];
                            numbers.Remove(numbers[0]);
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }

            var rounded = Math.Round(result, 5);
            Console.WriteLine(txt + "=" + rounded);
        }
    }
}
