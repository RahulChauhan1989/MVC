using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebAppBGV.CommonMethods
{
    public class clsCryptoRandomNumber : RandomNumberGenerator
    {
        public static RandomNumberGenerator rng;

        public clsCryptoRandomNumber()
        {
            rng = RandomNumberGenerator.Create();
        }

        /// A cryptographically strong random sequence of non-zero values.
        public override void GetNonZeroBytes(byte[] data)
        {
            rng.GetNonZeroBytes(data);
        }

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }

        public double NextDouble()
        {
            byte[] b = new byte[4];
            //rng.GetBytes(b);
            rng.GetNonZeroBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }

        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        //++++++++++++++++++++++My Code +++++++++++++

        public static string GetRandomAlphaNumeric()
        {
            RandomNumberGenerator rng1;
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            //char[] chars = new char[52];
            //chars = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6".ToCharArray();
            byte[] b = new byte[8];
            rng1 = RandomNumberGenerator.Create();
            rng1.GetNonZeroBytes(b);
            StringBuilder strBuilder = new StringBuilder();
            foreach (byte byt in b)
            {
                strBuilder.Append(chars[byt % (chars.Length)]);
            }
            return strBuilder.ToString();
        }
    }
}