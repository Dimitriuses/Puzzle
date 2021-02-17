using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CommandSystem
{
    Dictionary<string,Command> Commands;
    string ErrorCommand = "Command doesn't exist";
    CommandLog CommandLog;
    public string GetPreviosCommand() => CommandLog.GetNextCommand();
    public string GetNextCommand() => CommandLog.GetNextCommand();
    
    public CommandSystem()
    {
        Commands = new Dictionary<string, Command>();
        CommandLog = new CommandLog();

        DateCommand dateCommand = new DateCommand();
        HistoryCommand historyCommand = new HistoryCommand(CommandLog.GetLog,CommandLog.Clear,CommandLog.GetLogById);

        Commands.Add(dateCommand.Name, dateCommand);
        Commands.Add(historyCommand.Name, historyCommand);
    }

    public string Execute(string command)
    {
        CommandLog.Push(command);
        string[] roSplitCommand = command.Split(' ');
        string commandName = roSplitCommand[0];
        Command TMP;
        if (Commands.TryGetValue(commandName, out TMP))
        {
            var list = new List<string>(roSplitCommand);
            list.Remove(commandName);
            roSplitCommand = list.ToArray();
            return TMP.Execute(roSplitCommand);
        }
        else return ErrorCommand;
        
    }

    public bool TabulationComands(string tabArgument, out string[] choices)
    {
        int n = Commands.Keys.Count(x => x.Contains(tabArgument));
        if (n > 0)
        {
            choices = new string[n];
            choices = Commands.Where(x => x.Key.Contains(tabArgument)).Select(x => x.Key).ToArray<string>();
            return true;
        }
        else
        {
            choices = new string[1];
            choices[0] = "Command not found";
            return false;
        }
        
    }



}
