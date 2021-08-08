# FunctionalApp

A demonstration of a functional application written in C#.

## Why

The desire to write something in a functional paradigm was inspired by the video: https://www.youtube.com/watch?v=v7WLC5As6g4&list=WL&index=1

## How

```cs
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
```
```cs
using System;
using System.Linq;

var input = 20;

if (input.ValidateAll(x => x.IsPositive(),
                   x => x.LessThan(60),
                   x => x.GreaterThanOrEqualTo(0)))
{
    // ...
}
```
