using Iconic.Result;
using static System.Int32;

namespace Iconic.Console;

public static class Arguments
{
    public static bool Include(string[] args, string name){
        return Array.IndexOf(args, name) > -1;
    }

    public static Result<string?> GetStringValueResult(string[] args, string name){
        int argumentIndex = Array.IndexOf(args, name);
        int valueIndex = argumentIndex + 1;
        // Arg does not exist
        if(argumentIndex < 0){
            return new Result<string?>(false, $"You need to specify an argument {name}", null);
        }

        // Arg exists but valueIndex after last item
        if (args.Length == valueIndex)
        {
            return new Result<string?>(false, $"You need to specify a value for argument {name}", null);
        }

        if(args[valueIndex].Contains("--"))
        {
            return new Result<string?>(false, $"You need to specify a value for argument {name}. You provided a new argument {args[valueIndex]}", null);
        }
        return new Result<string?>(true, null, args[valueIndex]);
    }

    public static Result<int?> GetIntValueResult(string[] args, string name){
        var res = GetStringValueResult(args, name);

        if (res.Success)
        {
            if (TryParse(res.Data, out var i))
            {
                return new Result<int?>(true, null, i);
            }

            return new Result<int?>(false, $"You need to specify an int as a value for argument {name}. You provided '{res.Data}'", null);
        }

        return new Result<int?>(false, res.Message, null);
    }
}