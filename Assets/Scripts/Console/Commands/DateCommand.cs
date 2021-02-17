using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DateCommand : Command
{
    public DateCommand()
    {
        Name = "date";
    }
    public override string Execute(string[] args)
    {
        return "11:28:1999";
    }

    public override string GetHelp()
    {
        return "DATE - shows the date of birth of the developer";
    }

    public override string Manual()
    {
        return "just shows the date of birth of the developer";
    }
}

