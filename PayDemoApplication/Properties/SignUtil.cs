using System;
using System.Security.Cryptography;
using System.Text;

namespace PayDemoApplication.Properties
{
    public class SignUtil
    {
        /**
         * Generate Random Str
         */
        public static string GenerateRandomStr(int length)
        {
            var b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            var r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = null;
            str += "0123456789abcdefghijklmnopqrstuvwxyz";
            for (var i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }

            return s;
        }

        /**
         * Get UTC Timestamp
         */
        public static string GetTimeStamp()
        {
            return ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString();
        }


        /**
         * Generate Signature Str
         */
        public static string GetSign(string timeStamp, string randomStr)
        {
            var signStr =
                $"{SysConfig.TestMerchantCode}&{timeStamp}&{randomStr}&{SysConfig.TestMerchantGatewayCredential}";
            var bytes = Encoding.UTF8.GetBytes(signStr);
            var hash = SHA256.Create().ComputeHash(bytes);

            var builder = new StringBuilder();
            foreach (var t in hash)
            {
                builder.Append(t.ToString("X2"));
            }

            return builder.ToString().ToLower();
        }

        public static string AddSignToUri(string uri)
        {
            var randomStr = GenerateRandomStr(8);
            var timeStamp = GetTimeStamp();
            var sign = GetSign(timeStamp, randomStr);
            var requestUrl = $"{uri}?nonce_str={randomStr}&time={timeStamp}&sign={sign}";
            Console.WriteLine("Current Request Url  ==========> " + requestUrl);
            return requestUrl;
        }
    }
}