using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAnURL
{
    class DecodeURL
    {
        static string UrlDecoder(string getdecoded)
        {
            string helper = getdecoded;

            for (int i = 0; i < getdecoded.Length; i++)
            {


                if (helper.Contains("%20") == true)
                {
                    helper = helper.Replace("%20", " ");
                }
                else if (helper.Contains("%3A") == true)
                {
                    helper = helper.Replace("%3A", ":");
                }
                else if (helper.Contains("%3D") == true)
                {
                    helper = helper.Replace("%3D", "?");
                }
                else if (helper.Contains("%2F") == true)
                {
                    helper = helper.Replace("%2F", "/");
                }
            }
            return helper;
        }

        static void Main(string[] args)
        {
            string text = "kitten%20pic.jpg%3D%20two%2Fthree%3A2/3";
            Console.WriteLine(UrlDecoder(text));
            Console.Read();
        }
    }
}
