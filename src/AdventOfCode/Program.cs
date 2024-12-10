using AdventOfCode.Kit.Client.Models;
using AdventOfCode.Kit.Console;
using System.Runtime.CompilerServices;


var console = AdventOfCodeConsole.Instance;


console.StartYear(2024, year =>
{
    year.Submit<Day1>().ForDay(1);
});

class Day1 : Puzzle
{
    public override (Answer First, Answer Second) Run(string[] lines)
    {
        return (null, null);
    }
}