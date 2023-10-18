global using static System.Console;
using RPS;


var p = new Player("DIOGO");
var c = new Computer();
var g = new Game(p, c);

g.Play();

Write("Press any key to exit...");
ReadKey();