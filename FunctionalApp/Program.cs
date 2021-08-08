/*
using System;
using System.Linq;

var input = 20;

if (input.ValidateAll(x => x.IsPositive(),
                   x => x.LessThan(60),
                   x => x.GreaterThanOrEqualTo(0)))
{
    // ...
}
*/

using System;
using System.Linq;
using Functionals;
using static FunctionalApp.Application;

namespace FunctionalApp
{
    public class Program
    {
        public static void Main(string[] args) => args
            .Ignore()
            
            .With("Enter ", "something: ")
            .Do(x =>
                    Print(x.First()), x =>
                    Print(x.Last()))
            
            .With("You entered: ")
            .With(PromptUser)
            .Do(PrintWithLine)
            
            .With(_ => "End of program").Do(Print)
            .Do(Wait);
    }

    public static class Application
    {
        public static readonly Action<string> Print = Console.Write;
        public static readonly Action<string> PrintWithLine = Console.WriteLine;
        
        public static readonly Action<Nothing> Wait = _ => Console.ReadKey();
        
        public static readonly Func<string, string> PromptUser = x => x + Console.ReadLine();
    }
}