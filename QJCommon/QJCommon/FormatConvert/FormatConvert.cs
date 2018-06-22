using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QJCommon.FormatConvert
{
    class FormatConvert
    {
        /// <summary>
        /// byte数组转换成16进制的字符串
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>byte[]{ 0x30, 0x31} ==> "3031"</returns>
        public static string BytesToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)

            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)

                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        /// <summary>
        /// 16进制的数字字符串转成 byte数组
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns>“3031”==> byte[]{0x30, 0x31}</returns>
        public static byte[] HexStringToBytes(string hexString)
        {
            int discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (Uri.IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            //if odd number of characters, discard last character, discard:丢弃
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            byte[] returnBytes = new byte[newString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        


    }
}
