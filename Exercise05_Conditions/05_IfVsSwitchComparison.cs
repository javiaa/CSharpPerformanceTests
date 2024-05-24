using BenchmarkDotNet.Attributes;

namespace Conditions;

[MemoryDiagnoser(true)]
public class IfVsSwitchComparison
{

    private UserDto _user;
    private const string Username = "username1001";

    [GlobalSetup]
    public void Setup()
    {
        _user = new UserDto(Guid.NewGuid(), Username, DateTime.Now);
    }



    [Benchmark]
    public string Switch()
    {
        var a = "";
        switch (_user.Username)
        {
            case "case1":
                a = "case1";
                break;
            case "case2":
                a = "case2";
                break;
            case "case3":
                a = "case3";
                break;
            case "case4":
                a = "case4";
                break;
            case "case5":
                a = "case5";
                break;
            case "case6":
                a = "case6";
                break;
            case Username:
                a = Username;
                break;
            default:
                a = "default";
                break;
        }

        return a;
    }
    [Benchmark]
    public string IfElse()
    {
        var a = "";
        if (_user.Username == "case1")
        {
            a = "case1";
        }
        else if (_user.Username == "case2")
        {
            a = "case2";
        }
        else if (_user.Username == "case3")
        {
            a = "case3";
        }
        else if (_user.Username == "case4")
        {
            a = "case4";
        }
        else if (_user.Username == "case5")
        {
            a = "case5";
        }
        else if (_user.Username == "case6")
        {
            a = "case6";
        }
        else if (_user.Username == Username)
        {
            a = Username;
        }
        else
        {
            a = "default";
        }

        return a;
    }
}