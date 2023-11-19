namespace Iconic.Console;
using System;

public class Terminal
{
    public static void PrintIntInColor(string title, int data, int yellowThreshold, int greenThreshold, string suffix){
        Console.Write(title + ":\t\t");
        System.Console.ForegroundColor = data switch
        {
            100 => ConsoleColor.Green,
            < 100 and > 25 => ConsoleColor.Yellow,
            _ => ConsoleColor.Red
        };

        Console.Write(data + suffix + "\n");
        Console.ResetColor();
    }

    public static void PrintBoolInColor(string title, bool data, bool danger, bool reverse){
        Console.Write(title + ":\t");
        if(reverse){
            data = !data;
        }
        if(data){
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = danger ? ConsoleColor.Red : ConsoleColor.Yellow;
        }
        if(reverse){
            data = !data;
        }
        Console.Write(data + "\n");
        Console.ResetColor();
    }
    
    public static void PrintState(string title, string data, string greenValue, string yellowValue, string redValue){
        Console.Write(title + ":\t");

        if(data == greenValue){
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if(data == yellowValue){
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if(data == redValue) {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        Console.Write(data + "\n");
        Console.ResetColor();
    }

    public static void WriteInYellow(string message){
        WriteInColor(message, ConsoleColor.Yellow, false);
    }
    public static void WriteLineInYellow(string message){
        WriteInColor(message, ConsoleColor.Yellow, true);
    }

    public static void WriteInRed(string message){
        WriteInColor(message, ConsoleColor.Red, false);
    }
    public static void WriteLineInRed(string message){
        WriteInColor(message, ConsoleColor.Red, true);
    }
    
    public static void WriteInBlue(string message){
        WriteInColor(message, ConsoleColor.Blue, false);
    }
    public static void WriteLineInBlue(string message){
        WriteInColor(message, ConsoleColor.Blue, false);
    }
    
    public static void WriteInGreen(string message){
        WriteInColor(message, ConsoleColor.Green, false);
    }
    public static void WriteLineInGreen(string message){
        WriteInColor(message, ConsoleColor.Green, false);
    }
    
    public static void WriteInColor(string message, ConsoleColor color, bool line){
        Console.ForegroundColor = color;
        Console.Write(message);
        if (line) Console.WriteLine();
        Console.ResetColor();
    }
}
