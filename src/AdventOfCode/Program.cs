using AdventOfCode.Kit.Console;
using AdventOfCode.Puzzles;


var console = AdventOfCodeConsole.Instance;

console.StartYear(2024, year =>
{
    year.Submit<HistorianHysteria>().ForDay(1);
});

console.Run(args);