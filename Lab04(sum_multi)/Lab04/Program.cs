using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Program
    {
        class ZTwo
        {
            private static int BitCount(UInt16 value)
            {
                return Convert.ToString(value, 2).Length;
            }

            private static UInt16 mod(UInt16 val, UInt16 del)
            {
                if (val < del) return val;

                while (val >= del)
                {
                    //получаем "маску", сдвигая делитель влево
                    UInt16 mask = (UInt16)(del << BitCount(val) - BitCount(del));

                    val ^= mask;
                }

                return val;
            }

            public byte Value { get; set; }

            public static ZTwo operator +(ZTwo a, ZTwo b)
            {
                return new ZTwo() { Value = (byte)(a.Value ^ b.Value) };
            }

            public static ZTwo operator *(ZTwo a, ZTwo b)
            {
                UInt16 result = 0, uint_a = a.Value, uint_b = b.Value;

                //"обычное" умножение
                for (int i = 0; i < 8; i++)
                {
                    result ^= (UInt16)(uint_a * (uint_b & ((UInt16)1 << i)));
                }

                result = mod(result, 283);

                return new ZTwo() { Value = (byte)result };
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter some X: ");
            ZTwo x = new ZTwo() { Value = Convert.ToByte(Console.ReadLine(), 2) };

            Console.WriteLine("Enter some Y: ");
            ZTwo y = new ZTwo() { Value = Convert.ToByte(Console.ReadLine(), 2) };

            Console.WriteLine("\n{0} + {1} = {2}\n",
                Convert.ToString(x.Value, 2).PadLeft(8, '0'),
                Convert.ToString(y.Value, 2).PadLeft(8, '0'),
                Convert.ToString((x + y).Value, 2).PadLeft(8, '0'));

            Console.WriteLine("{0} * {1} = {2}\n",
                Convert.ToString(x.Value, 2).PadLeft(8, '0'),
                Convert.ToString(y.Value, 2).PadLeft(8, '0'),
                Convert.ToString((x * y).Value, 2).PadLeft(8, '0'));
            
            Console.ReadLine();
        }
    }
}
