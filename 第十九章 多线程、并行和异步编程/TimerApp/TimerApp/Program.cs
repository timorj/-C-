using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("*******Working with Time type*****\n");

            TimerCallback timeCB = new TimerCallback(PrintTime);

            Timer t = new Timer(timeCB, "Hello From Main", 0, 1000);

            Console.WriteLine("Hit key to terminate...");*/

            Solution s = new Solution();
            Console.WriteLine(s.MyAtoi("-42878"));
            Console.ReadLine();

        }
        static void PrintTime(object state)
        {
            Console.WriteLine("Time is:{0}, Params is {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }
    }
    public class Solution
    {
        public int MyAtoi(string s)
        {
            char[] chars = s.ToCharArray();
            string result = String.Empty;
            int intResult;
            int i = 0;
            bool isNeg = false;
            for (int k = 0; k < chars.Length; k++)
            {
                if (chars[k] == '-')
                {
                    result += "-";
                    isNeg = true;
                    i = k;
                }
                else 
                {
                    break;
                }
            }
            if (isNeg)
            {
                i++;
                if (i == chars.Length - 1)
                {
                    return 0;
                }
                else
                {
                    for (int j = i; j < chars.Length; j++)
                    {
                        if (int.TryParse(chars[j].ToString(), out int n))
                        {
                            result += chars[j].ToString();
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                try
                {
                    checked
                    {
                        if (result == "-")
                            return 0;
                        intResult = int.Parse(result);
                        return intResult;
                    }
                }
                catch
                {
                    return int.MinValue;
                }
            }
            else
            {
                i = 0;
                while (int.TryParse(chars[i].ToString(), out int n) && i > chars.Length - 1)
                {
                    i++;
                }
                for (int j = i; j < chars.Length; j++)
                {
                    if (int.TryParse(chars[j].ToString(), out int n))
                    {
                        result += chars[j].ToString();
                    }
                    else
                    {
                        break;
                    }
                }
                try
                {
                    checked
                    {
                        if (result == string.Empty)
                            return 0;
                        intResult = int.Parse(result);
                        return intResult;
                    }
                }
                catch
                {
                    return int.MaxValue;
                }
            }
        }
    }
}
