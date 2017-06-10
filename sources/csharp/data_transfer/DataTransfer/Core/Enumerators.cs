using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DataTransfer.Core
{
    public class Enumerators
    {
        public enum LogColor 
            : byte
        {
            Success = ConsoleColor.Green,
            Error = ConsoleColor.Red,
            Information = ConsoleColor.White
        }
    }
}