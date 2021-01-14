using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GRUBMenu : MonoBehaviour
{
    public List<string> OS;
    public Text Text;

    static char VERTICALINE = '│';
    static char HORISONTALINE = '─';
    static char UPRIGHTCORNER = '┐';
    static char UPLEFTCOTNER = '┌';
    static char DOWNRIGHTCORNER = '┘';
    static char DOWNLEFTCORNER = '└';

    string upBorderLine;
    string downBorderLine;
    // Start is called before the first frame update
    void Start()
    {
        //Text.CalculateLayoutInputHorizontal();
        int tmpHeight = GetMaxLineCount(Text);
        int tmpWidth = GetMaxCharLineCount(Text);
        //Debug.Log( tmpHeight + " " + tmpWidth);
        string tmpBorder = "";
        for(int i = 0; i<=tmpHeight; i++)
        {
            for(int j = 0; j<=tmpWidth; j++)
            {
                tmpBorder +=
                    (i == 0 && j == 0) ? UPLEFTCOTNER :
                    (i == 0 && j == tmpWidth) ? UPRIGHTCORNER :
                    (i == tmpHeight && j == tmpWidth) ? DOWNRIGHTCORNER :
                    (i == tmpHeight && j == 0) ? DOWNLEFTCORNER :
                    ((i == 0 || i == tmpHeight) && j < tmpWidth) ? HORISONTALINE :
                    (i > 0 && (j == 0 || j == tmpWidth)) ? VERTICALINE : ' ';

            }
            tmpBorder += "\n";
        }
        Text.text = tmpBorder;
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

    // Update is called once per frame
    void Update()
    {

    }
}
