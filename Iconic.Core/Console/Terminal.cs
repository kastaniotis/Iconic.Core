namespace Iconic.Console;

public static class Terminal
{
    public static void PrintIntInColor(string title, int data, int yellowThreshold, int greenThreshold, string suffix){
        System.Console.Write(title);
        System.Console.ForegroundColor = data switch
        {
            100 => ConsoleColor.Green,
            < 100 and > 25 => ConsoleColor.Yellow,
            _ => ConsoleColor.Red
        };

        System.Console.Write(data + suffix + "\n");
        System.Console.ResetColor();
    }

    public static void PrintBoolInColor(string title, bool data, bool danger, bool reverse){
        System.Console.Write(title);
        if(reverse){
            data = !data;
        }
        if(data){
            System.Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            System.Console.ForegroundColor = danger ? ConsoleColor.Red : ConsoleColor.Yellow;
        }
        if(reverse){
            data = !data;
        }
        System.Console.Write(data + "\n");
        System.Console.ResetColor();
    }
    
    public static void PrintState(string title, string data, string greenValue, string yellowValue, string redValue){
        System.Console.Write(title);

        if(data == greenValue){
            System.Console.ForegroundColor = ConsoleColor.Green;
        }
        else if(data == yellowValue){
            System.Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if(data == redValue) {
            System.Console.ForegroundColor = ConsoleColor.Red;
        }

        System.Console.Write(data + "\n");
        System.Console.ResetColor();
    }

    public static void WriteInYellow(string? message){
        WriteInColor(message, ConsoleColor.Yellow, false);
    }
    public static void WriteLineInYellow(string? message){
        WriteInColor(message, ConsoleColor.Yellow, true);
    }

    public static void WriteInRed(string? message){
        WriteInColor(message, ConsoleColor.Red, false);
    }
    public static void WriteLineInRed(string? message){
        WriteInColor(message, ConsoleColor.Red, true);
    }
    
    public static void WriteInBlue(string? message){
        WriteInColor(message, ConsoleColor.Blue, false);
    }
    public static void WriteLineInBlue(string? message){
        WriteInColor(message, ConsoleColor.Blue, true);
    }
    
    public static void WriteInGreen(string? message){
        WriteInColor(message, ConsoleColor.Green, false);
    }
    public static void WriteLineInGreen(string? message){
        WriteInColor(message, ConsoleColor.Green, true);
    }
    
    public static void WriteInColor(string? message, ConsoleColor color, bool line){
        System.Console.ForegroundColor = color;
        System.Console.Write(message);
        if (line) System.Console.WriteLine();
        System.Console.ResetColor();
    }
}
