using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertString
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "Test 123";
            Console.WriteLine(message);
            message = InvertString(message);
            Console.WriteLine(message);
            Console.ReadKey();
        }

static string InvertString(string message)
{
    var invertedString = string.Empty;

    if (string.IsNullOrEmpty(message))
        throw new ArgumentNullException ("\"message\" can't be null");

    for (var i = 0; i < message.Length; i++)
    {
        var idx = message.Length - (i + 1);
        invertedString += message[idx];
    }

    return invertedString;
}
    }
}
