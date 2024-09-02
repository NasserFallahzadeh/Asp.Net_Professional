// See https://aka.ms/new-console-template for more information

using ConsoleApp;

var mathHelper = new MathHelper();

while (true)
{
    Console.WriteLine("X ra verd kind ...");
    var x=Convert.ToInt32(Console.ReadLine());


    Console.WriteLine("Y ra verd kind ...");
    var y=Convert.ToInt32(Console.ReadLine());

    var result = mathHelper.Jam(x, y);

    Console.WriteLine($"X:{x} + Y:{y} = {result}");
}

Console.ReadLine();
