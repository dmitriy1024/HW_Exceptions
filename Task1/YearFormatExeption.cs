using System;

namespace Task1
{
    class YearFormatExeption : Exception
    {
        public YearFormatExeption() {}

        public YearFormatExeption(string message) : base(message) {}
    }
}
