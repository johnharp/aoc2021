using System;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            var el = Element.CreateElementFromString(
                "[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]");

            Console.WriteLine(el);

        }
    }
}
