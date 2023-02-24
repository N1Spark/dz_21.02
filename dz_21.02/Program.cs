using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_21._02
{
    class Program
    {
        public class Object
        {
            public string Name { get; set; }
            public double Value { get; set; }
            public Object() { }
            public Object(string name, double value)
            {
                Name = name;
                Value = value;
            }
        }

        public class Backpack
        {
            public string Color { get; set; }
            public string Brand { get; set; }
            public string Type { get; set; }
            public double Weigth { get; set; }
            public double Volume { get; set; }
            public double UsedVolume { get; set; }

            public List<Object> Objects { get; set; } = new List<Object>();

            public event EventHandler<Object> PackAdd;

            public Backpack() { }
            public Backpack(string color, string brand, string type, double weigth, double volume)
            {
                Color = color;
                Brand = brand;
                Type = type;
                Weigth = weigth;
                Volume = volume;
            }
            public void Init()
            {
                Console.WriteLine("Color: ");
                Color = Console.ReadLine();
                Console.WriteLine("Brand: ");
                Brand = Console.ReadLine();
                Console.WriteLine("Type: ");
                Type = Console.ReadLine();
                Console.WriteLine("Weigth: ");
                Weigth = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Volume: ");
                Volume = Convert.ToDouble(Console.ReadLine());
            }
            public void AddObj(Object obj)
            {
                if (obj.Value + UsedVolume > Volume)
                    throw new Exception("Объем предметов больше чем рюкзак");
                Objects.Add(obj);
                UsedVolume += obj.Value;
                PackAdd?.Invoke(this, obj);
            }
        }
        static void PackChange()
        {
            Console.WriteLine("Рюкзак создан");
        }
        static void PackAdd()
        {
            Console.WriteLine("В рюкзак был добавлен предмет");
        }

        delegate string Func_1(RainbowColor color);
        delegate int Func_3(int[] a);
        delegate int Func_4(int[] a);
        delegate void Func_5(int[] a);
        delegate bool Func_6(string a, string b);
        public enum RainbowColor
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }
        static void Main(string[] args)
        {
            #region 1
            RainbowColor color = RainbowColor.Red;
            Func_1 func_1 = delegate (RainbowColor x)
            {
                string buf = "";
                switch (x)
                {
                    case RainbowColor.Red:
                        return buf = "255, 0, 0";
                    case RainbowColor.Orange:
                        return buf = "255, 165, 0";
                    case RainbowColor.Yellow:
                        return buf = "255, 255, 0";
                    case RainbowColor.Green:
                        return buf = "0, 128, 0";
                    case RainbowColor.Blue:
                        return buf = "0, 0, 255";
                    case RainbowColor.Indigo:
                        return buf = "75, 0, 13";
                    case RainbowColor.Violet:
                        return buf = "238, 130, 238";
                    default:
                        return buf = "0, 0, 0";
                }
            };
            Console.WriteLine(func_1(color));
            #endregion

            #region 2
            Backpack backpack = new Backpack("Черный", "Off White", "Брезентовый", 1.0, 20);
            backpack.PackAdd += (sender, item) =>
            {
                Console.WriteLine($"Объект {item.Name} добавлен в рюкзак");
            };
            Object obj = new Object("Ноутбук", 3.0);
            try
            {
                backpack.AddObj(obj);
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            #endregion

            #region 3
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Func_3 func_3 = (int[] x) =>
            {
                int count = 0;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] % 7 == 0 && x[i] != 0)
                        count++;
                return count;
            };
            Console.WriteLine(func_3(arr));
            #endregion

            #region 4
            int[] arr2 = new int[] { 1, 2, 3, 4, 5, 6, -10, -9, -9, -8 };
            Func_4 func_4 = (int[] x) =>
            {
                int buf_4 = 0;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] > 0)
                        buf_4++;
                return buf_4;
            };
            Console.WriteLine(func_4(arr2));
            #endregion

            #region 5
            Func_5 func_5 = (int[] x) =>
            {
                var buf = x.Where(y => y < 0).Distinct();
                foreach (var result in buf)
                    Console.Write(result + " ");
                Console.WriteLine();
            };
            #endregion

            #region 6
            string text = "Hello World";
            string search = "Hello";
            Func_6 func_6 = (text_1, search_1) =>
            {
                if (text_1.IndexOf(search_1) != -1)
                    return true;
                else
                    return false;
            };
            Console.WriteLine(func_6(text, search));
            #endregion
        }
    }
}
