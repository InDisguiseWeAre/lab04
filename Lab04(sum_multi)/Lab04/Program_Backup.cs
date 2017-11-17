using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Program_Backup
    {
        public static int GetLen(uint val)
        {
            return Convert.ToString(val, 2).Length;
        }

        class ZTwo
        {
            public byte Value { get; set; }

            private static uint MOD(uint one, uint two)
            {
                while (one >= two)
                {
                    one = Convert.ToUInt16((one ^ (two << GetLen(one) - GetLen(two))));
                }
                //one = Convert.ToUInt16((one ^ (two << GetLen(one) - GetLen(two)) & UInt16.MaxValue));
                //one = (UInt16)(one ^ (two << GetLen(one) - GetLen(two)));

                return one;
            }

            public static implicit operator ZTwo(byte val)
            {
                return new ZTwo() { Value = val };
            }

            public static explicit operator byte(ZTwo val)
            {
                return val.Value;
            }

            public static ZTwo operator +(ZTwo one, ZTwo two)
            {
                return new ZTwo { Value = (byte)(one.Value ^ two.Value) };
            }

            public static ZTwo operator *(ZTwo one, ZTwo two)
            {
                uint a = (byte)one, b = (byte)two, result = 0;

                //умножение
                
                for (int i = 0; i < 8; i++)
                {
                    result ^= (a * (b & ((uint)1 << i)));
                }

                Console.WriteLine("{0} * {1} = {2}",
                    Convert.ToString(a, 2).PadLeft(8, '0'),
                    Convert.ToString(b, 2).PadLeft(8, '0'),
                    Convert.ToString(result, 2));

                //остаточное деление

                if (result > byte.MaxValue)
                {
                    Console.WriteLine("{0} mod {1} = {2}",
                        Convert.ToString(result, 2),
                        Convert.ToString(283, 2),
                        Convert.ToString(MOD(result, 283), 2).PadLeft(8, '0'));

                    return new ZTwo() { Value = (byte)MOD(result, 283) };
                }

                return new ZTwo() { Value = (byte)result };
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        /*static void Main(string[] args)
        {
            Console.WriteLine((ZTwo)21 * (ZTwo)11);

            Console.ReadLine();
        }*/

        public static void TMain(string[] args)
        {
            /*
            ZTwo first = new ZTwo { Value = Convert.ToByte(Console.ReadLine(), 2) };
            ZTwo second = new ZTwo { Value = Convert.ToByte(Console.ReadLine(), 2) };

            ZTwo result = first * second;
            */

            //Console.WriteLine((ZTwo)15 * (ZTwo)15);

            UInt16 num = Convert.ToByte(Console.ReadLine(), 2), mod = Convert.ToByte(Console.ReadLine(), 2);

            while (num >= mod)
            {
                num = Convert.ToUInt16((num ^ (mod << Convert.ToString(num, 2).Length - Convert.ToString(mod, 2).Length)));
            }
            //num = Convert.ToUInt16((num ^ (mod << Convert.ToString(num, 2).Length - Convert.ToString(mod, 2).Length)) & UInt16.MaxValue);

            Console.WriteLine("Result mod: " + Convert.ToString(num, 2));

            /*
            Console.WriteLine("Enter x");
            Byte x = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter y");
            Byte y = Convert.ToByte(Console.ReadLine());

            //сложение
            Byte result = Convert.ToByte(x ^ y);
            Console.WriteLine("Result sum: ");

            //умножение
            Int16 mult = 0;
            for (byte i = 0; i < 8; i++)
                mult ^= Convert.ToInt16((y * ((x >> i) & 1)) << i);
            Console.WriteLine("Result mult: " + Convert.ToString(mult, 2));

            //деление
            UInt16 num = Convert.ToUInt16(Console.ReadLine(), 16);
            UInt16 mod = Convert.ToUInt16(Console.ReadLine(), 16);
            //UInt16 num=Convert.ToUInt16("",2);
            // UInt16 mod=Convert.ToUInt16("",2);  

            while (num > mod)
            {
                num = Convert.ToUInt16((num ^ (mod << Convert.ToString(num, 2).Length - Convert.ToString(mod, 2).Length)));
            }
            num = Convert.ToUInt16((num ^ (mod << Convert.ToString(num, 2).Length - Convert.ToString(mod, 2).Length)) & UInt16.MaxValue);

            Console.WriteLine("Result mod: " + Convert.ToString(num, 2));
            */

            Console.ReadLine();
        }
    }
}
