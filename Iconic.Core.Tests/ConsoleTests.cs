using Iconic.Console;
using Iconic.Result;

namespace Iconic.Tests;

public class ConsoleArgsTests
{
    [Test]
    public void TestInclude()
    {

        string[] args = { };

        bool test = Arguments.Include(args, "--json");
        Assert.That(test, Is.EqualTo(false));
        
        args = new []{ "--json"};
        
        test = Arguments.Include(args, "--json");
        Assert.That(test, Is.EqualTo(true));
        
    }

    [Test]
    public void TestGetString()
    {
        string[] args = Array.Empty<string>();

        Result<string?> test = Arguments.GetStringValueResult(args, "--port");
        Assert.That(test.Success, Is.EqualTo(false));
        Assert.That(test.Data, Is.EqualTo(null));
        Assert.That(test.Message, Is.EqualTo($"You need to specify an argument --port"));

        args = new[] { "--port" };
        test = Arguments.GetStringValueResult(args, "--port");
        Assert.That(test.Success, Is.EqualTo(false));
        Assert.That(test.Data, Is.EqualTo(null));
        Assert.That(test.Message, Is.EqualTo($"You need to specify a value for argument --port"));

        args = new[] { "--port", "--wrong" };
        test = Arguments.GetStringValueResult(args, "--port");
        Assert.That(test.Success, Is.EqualTo(false));
        Assert.That(test.Data, Is.EqualTo(null));
        Assert.That(test.Message,
            Is.EqualTo($"You need to specify a value for argument --port. You provided a new argument --wrong"));

        args = new[] { "--port", "correct" };
        test = Arguments.GetStringValueResult(args, "--port");
        Assert.That(test.Success, Is.EqualTo(true));
        Assert.That(test.Data, Is.EqualTo("correct"));
        Assert.That(test.Message, Is.EqualTo(null));
    }
    
    [Test]
    public void TestGetInt()
    {
        var args = new[] { "--port", "wrong" };
        var test2 = Arguments.GetIntValueResult(args, "--port");
        Assert.That(test2.Success, Is.EqualTo(false));
        Assert.That(test2.Data, Is.EqualTo(null));
        Assert.That(test2.Message, Is.EqualTo($"You need to specify an int as a value for argument --port. You provided 'wrong'"));
        
        args = new[] { "--port" };
        test2 = Arguments.GetIntValueResult(args, "--port");
        Assert.That(test2.Success, Is.EqualTo(false));
        Assert.That(test2.Data, Is.EqualTo(null));
        Assert.That(test2.Message, Is.EqualTo($"You need to specify a value for argument --port"));
        
        args = new[] { "--port", "2" };
        test2 = Arguments.GetIntValueResult(args, "--port");
        Assert.That(test2.Success, Is.EqualTo(true));
        Assert.That(test2.Data, Is.EqualTo(2));
        Assert.That(test2.Message, Is.EqualTo(null));
    }
}