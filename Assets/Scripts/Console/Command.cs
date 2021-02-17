using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Command
{
    public string Name;
    public abstract string Execute(string[] args);
    public abstract string GetHelp();
    public abstract string Manual();
}
