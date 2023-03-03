using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace 第一題
{





    class Program
    {
        static void Main(string[] args)
        {


            var list =
                 File.ReadAllLines(@"product.csv")
                .Skip(1)
                .Select(it => it.Split(','));




            List<Product> result = new List<Product>();
            foreach (var line in list)
            {
                Product p = new Product();
                p.ID = line[0];
                p.Name = line[1];
                p.Quantity = line[2];
                p.Price = line[3];
                p.Class = line[4];
                p.Quantity_int = Convert.ToInt32(p.Quantity);
                p.Price_int = Convert.ToInt32(p.Price);

                result.Add(p);

            }

            var category = result.GroupBy(x => x.Class);


            var a1 = result.Sum((x) => x.Price_int);
            Console.WriteLine("1.計算所有商品的總價格");
            Console.WriteLine(a1);
            Console.WriteLine();

            var a2 = result.Average((x) => x.Price_int);
            Console.WriteLine("2.計算所有商品的平均價格");
            Console.WriteLine(a2);
            Console.WriteLine();

            var a3 = result.Sum((x) => x.Quantity_int);
            Console.WriteLine("3.計算商品的總數量");
            Console.WriteLine(a3);
            Console.WriteLine();

            var a4 = result.Average((x) => x.Quantity_int);
            Console.WriteLine("4.計算商品的平均數量");
            Console.WriteLine(a4);
            Console.WriteLine();

            var a5 = result.OrderByDescending((x) => x.Price_int).First().Name;
            Console.WriteLine("5.找出哪一項商品最貴");
            Console.WriteLine(a5);
            Console.WriteLine();

            var a6 = result.OrderBy((x) => x.Price_int).First().Name;
            Console.WriteLine("6.找出哪一項商品最便宜");
            Console.WriteLine(a6);
            Console.WriteLine();

            var a7 = result.Where((x) => x.Class == "3C").Sum((x) => x.Price_int);
            Console.WriteLine("7.計算產品類別為3C的商品總價");
            Console.WriteLine(a7);
            Console.WriteLine();

            var a8 = result.Where((x) => x.Class == "飲料" || x.Class == "食品").Sum((x) => x.Price_int);
            Console.WriteLine("8. 計算產品類別為飲料及食品的商品總價");
            Console.WriteLine(a8);
            Console.WriteLine();

            var a9 = result.Where((x) => x.Class == "食品" && x.Quantity_int > 100);
            Console.WriteLine("9. 找出所有商品類別為食品，而且商品數量大於100的商品");
            foreach (var a in a9)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine();

            Console.WriteLine("10. 找出各個商品類別底下有哪些商品的價格是大於1000的商品");
            foreach (var a in category)
            {
                var item = a.Where(x => x.Price_int > 1000);

                if (item != null)
                {
                    Console.WriteLine($"{a.Key}");
                    foreach (var b in item)
                    {
                        Console.Write($"---{b.Name}\n");
                    }
                }
                
            }
            Console.WriteLine("11. 呈上題，請計算該類別底下所有商品的平均價格");
            foreach (var a in category)
            {
                Console.WriteLine($"{a.Key}類的平均價格為{a.Average(x => x.Price_int):N2}");
            }
            Console.WriteLine();
                    
            var a12 = result.OrderByDescending((x) => x.Price_int);
            Console.WriteLine("12. 依照商品價格由高到低排序");
            foreach (var a in a12)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine();

            var a13 = result.OrderBy((x) => x.Quantity_int);
            Console.WriteLine("13. 依照商品數量低到高排序");
            foreach (var a in a13)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine();


            Console.WriteLine("14. 找出各商品類別底下，最貴的商品");
            foreach (var a in category)
            {
                Console.WriteLine($"{a.Key}類中最貴的商品為{a.Max(x => x.Price_int)}");
            }
            Console.WriteLine();

            Console.WriteLine("15. 找出各商品類別底下，最便宜的商品");
            foreach (var a in category)
            {
                Console.WriteLine($"{a.Key}類中最便宜的商品為{a.Min(x => x.Price_int)}");
            }
            Console.WriteLine();




            var a16 = result.Where((x) => x.Price_int <= 10000);
            Console.WriteLine("16. 找出價格小於等於10000的商品");
            foreach (var a in a16)
            {
                Console.WriteLine(a.Name);
            }

            

            Console.ReadLine();




        }
    }


}
