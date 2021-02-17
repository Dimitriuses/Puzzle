using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HistoryCommand : Command
{
    public delegate string[] GetHistory();
    GetHistory getHistory;

    public delegate void DeleteHistory();
    DeleteHistory deleteHistory;

    public delegate bool GetHistoryById(int id, out string value);
    GetHistoryById getHistoryById;

    public HistoryCommand(GetHistory getHistory,DeleteHistory deleteHistory, GetHistoryById getHistoryById)
    {
        this.getHistory = getHistory;
        this.deleteHistory = deleteHistory;
        this.getHistoryById = getHistoryById;

        Name = "history";
    }
    
    public override string Execute(string[] args)
    {
        string rez = string.Empty;
        if (args.Length != 0)
        {
            switch (args[0])
            {
                case "clear":
                    deleteHistory();
                    rez = "History cleared";
                    break;
                case "get":
                    int parse;
                    if(args.Length > 1 && int.TryParse(args[1],out parse))
                    {
                        getHistoryById(parse, out rez);
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            string[] getarray = getHistory();
            foreach (string item in getarray)
            {
                rez = rez + item + '\n';
            }
        }
        return rez;
    }

    public override string GetHelp()
    {
        return "";
    }

    public override string Manual()
    {
        return "";
    }
}