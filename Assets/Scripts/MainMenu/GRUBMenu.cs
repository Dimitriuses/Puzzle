using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GRUBMenu : MonoBehaviour
{
    public List<string> OSList;
    public Text Text;

    static char VERTICALINE = '│';
    static char HORISONTALINE = '─';
    static char UPRIGHTCORNER = '┐';
    static char UPLEFTCOTNER = '┌';
    static char DOWNRIGHTCORNER = '┘';
    static char DOWNLEFTCORNER = '└';

    string upBorderLine;
    string downBorderLine;

    int _selectId;
    int SelectId { get { return _selectId; } set
        {
            if(value>=0 || value <= OSList.Count - 1)
            {
                _selectId = value;
            }
            else if( value < 0)
            {
                _selectId = OSList.Count - 1;
            }
            else if (value > OSList.Count)
            {
                _selectId = 0;
            }
            RenderMenu();
        } }

    int MaxHeight;
    int MaxWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Text.CalculateLayoutInputHorizontal();
        //Debug.Log( tmpHeight + " " + tmpWidth);
        SelectId = 0;
        //string tmpBorder = "";
        OnRectTransformDimensionsChange();
        RenderMenu();
        //for (int i = 0; i<= MaxHeight; i++)
        //{
        //    for(int j = 0; j<= MaxWidth; j++)
        //    {
        //        tmpBorder +=
        //            (i == 0 && j == 0) ? UPLEFTCOTNER :
        //            (i == 0 && j == MaxWidth) ? UPRIGHTCORNER :
        //            (i == MaxHeight && j == MaxWidth) ? DOWNRIGHTCORNER :
        //            (i == MaxHeight && j == 0) ? DOWNLEFTCORNER :
        //            ((i == 0 || i == MaxHeight) && j < MaxWidth) ? HORISONTALINE :
        //            (i > 0 && (j == 0 || j == MaxWidth)) ? VERTICALINE : ' ';

        //    }
        //    tmpBorder += "\n";
        //}
        //Text.text = tmpBorder;
    }

    private void OnRectTransformDimensionsChange()
    {
        MaxHeight = GetMaxLineCount(Text);
        MaxWidth = GetMaxCharLineCount(Text);
        PreRenderBorder();
    }
    private void OnSelectIdChange()
    {
        
    }

    public static int GetMaxLineCount(Text text)
    {
        var textGenerator = new TextGenerator();
        var generationSettings = text.GetGenerationSettings(text.rectTransform.rect.size);
        var lineCount = 0;
        var s = new StringBuilder();
        while (true)
        {
            s.Append("\n");
            textGenerator.Populate(s.ToString(), generationSettings);
            var nextLineCount = textGenerator.lineCount;
            if (lineCount == nextLineCount) break;
            lineCount = nextLineCount;
        }
        return lineCount - 1;
    }
    public static int GetMaxCharLineCount(Text text)
    {
        var textGenerator = new TextGenerator();
        var generationSettings = text.GetGenerationSettings(text.rectTransform.rect.size);
        Vector2 size = text.rectTransform.rect.size;
        var s = new StringBuilder();
        return (int)(size.x / textGenerator.GetPreferredWidth(" ", generationSettings)) - 1;
    }

    private void PreRenderBorder()
    {
        upBorderLine = "";
        downBorderLine = "";
        for (int i = 0; i <= MaxWidth; i++)
        {
            upBorderLine += (i == 0) ? UPLEFTCOTNER : (i < MaxWidth) ? HORISONTALINE : UPRIGHTCORNER;
            downBorderLine += (i == 0) ? DOWNLEFTCORNER : (i < MaxWidth) ? HORISONTALINE : DOWNRIGHTCORNER;
        }
    }

    private void RenderMenu()
    {
        if (SelectId >= 0 && SelectId <= OSList.Count)
        {
            string tmpMenu = upBorderLine + "\n";
            for(int i = 0; i <= MaxHeight - 2; i++)
            {
                tmpMenu += RenderLine((OSList.Count > i) ? OSList[i] : "", i == SelectId) + "\n";
            }
            Text.text = tmpMenu + downBorderLine;
        }
    }

    private string RenderLine(string str,bool selected)
    {
        string TMPline = "" + VERTICALINE;
        if (selected)
        {
            TMPline += "<mark=#ffffff><color=black>";
        }
        TMPline += str;
        for (int i = 0; i <= MaxWidth-2-str.Length; i++)
        {
            TMPline += " ";
        }
        if (selected)
        {
            TMPline += "</color></mark>";
        }
        return TMPline + VERTICALINE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            SelectId++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            SelectId--;
        }
    }
}
