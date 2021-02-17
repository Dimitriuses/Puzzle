using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CommandLog
{
    LinkedList<string> Commands;
    LinkedListNode<string> CurrentCommand;

    //public delegate string[] GetHistory();
    //public delegate void DeleteHistory();

    public CommandLog()
    {
        Commands = new LinkedList<string>();
    }

    public void Push(string command)
    {
        CurrentCommand = Commands.AddLast(command);
    }

    public string GetNextCommand()
    {
        if (CurrentCommand.Next != null)
        {
            CurrentCommand = CurrentCommand.Next;
            return CurrentCommand.Value;
        }
        else return string.Empty;
    }

    public string GetPreviousCommand()
    {
        if (CurrentCommand.Previous != null)
        {
            CurrentCommand = CurrentCommand.Previous;
        }
        return CurrentCommand.Value;
    }

    public string GetLogToString()
    {
        string result = "";
        foreach (string item in Commands)
        {
            result = result + item + '\n';
        }
        return result;
    }

    public string[] GetLog()
    {
        return Commands.ToArray();
    }

    public bool GetLogById(int id, out string value)
    {
        string[] rez = GetLog();

        if(id < rez.Length && id > 0)
        {
            
            value = rez[rez.Length - 1];
            return true;
        }
        else
        {
            value = "id out of log length";
            return false;
        }
    }

    public void Clear()
    {
        Commands.Clear();
        CurrentCommand = new LinkedListNode<string>(string.Empty);
    }

}
