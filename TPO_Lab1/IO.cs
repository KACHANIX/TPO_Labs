using System;

namespace TPO_Lab1
{
    public static class IO
    {
        public static Action<string> WriteLine;
        public static Action<string> Write;
        public static Func<ConsoleKeyInfo> ReadKey;
        public static Func<string> ReadLine;
        public static Action Clear;
    }
}