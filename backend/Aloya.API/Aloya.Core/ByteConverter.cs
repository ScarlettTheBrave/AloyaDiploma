using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core
{
    public static class ByteConverter
    {
        public static byte[] GetBytes(string s)
        {
            
            string[] parts = s.Split(',');
            byte[] bytes = new byte[parts.Length];
            for(int i = 0;i < parts.Length;i++)
            {
                bytes[i] = Convert.ToByte(parts[i]);
            }
            return bytes;
        }
        public static string GetString(byte[] bts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bts.Length; i++)
            {
                sb.Append(bts[i]);
                if (i < bts.Length - 1)
                {
                    sb.Append(",");
                }
            }
            return sb.ToString();
        }
    }
}
