using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第二題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random num = new Random();

            bool play = false;

            while (!play)
            {
                int[] a = new int[4];

                do
                {
                    for (int i = 0; i < 4; i++)
                    {
                        a[i] = num.Next(0, 10);
                    }
                } while (a[0] == a[1] || a[0] == a[2] || a[0] == a[3] || a[1] == a[2] || a[1] == a[3] || a[2] == a[3]);


                string[] b = new string[4];

                for (int i = 0; i < 4; i++)
                    b[i] = Convert.ToString(a[i]);
                Console.WriteLine("歡迎來到1A2B猜數字的遊戲～");
                Console.WriteLine("------");

                foreach (string i in b)
                    Console.Write(i);

                int A;
                int B;
                do
                {
                    Console.Write("請輸入4個數字：");
                    string n = Console.ReadLine();
                   
                    A = 0; B = 0;
                    
                    for (int i = 0; i < 4; i++)
                    {
                        if (n.Substring(i, 1) == b[i])
                            A++;
                        else if (n.Contains(b[i]))
                            B++;
                    }
                    Console.WriteLine($"判定結果是{A}A{B}B");
                    Console.WriteLine("------");

                } while (A != 4);
                play = true;
                Console.WriteLine("恭喜你！猜對了！！");
                Console.WriteLine("------");
                Console.Write("你要繼續玩嗎?(y/n):");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    play = false;
                }
                else if (input == "n")
                {
                    Console.WriteLine("遊戲結束，下次再來玩喔~");
                }
            }
        }
    }
}
