﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StartLoad : MonoBehaviour
{
    public Image ResizeControlImage;
    public Sprite Sprite;
    public TextMeshProUGUI UperText;
    public RectTransform UperTextRectTransform;
    public TextMeshProUGUI CenterText;
    public TextMeshProUGUI DownerText;
    [Range(0, 100)]
    public int LoadStatus;
    [Range(0, 100)]
    public int memTestStatus;
    [Range(0, 100)]
    public int IDEDetectStatus;
    public bool StartBios;
    public float FontSize;

    int memSize = 4194304;
    string Info;
    string ProcInfo;
    string MemTest;
    string DetectIDEvice;
    string DetectedDevices;
    
    // Start is called before the first frame update
    void Start()
    {
        Info = "ASUS A7N8X2.0 Deluxe ACPI BIOS REV 1008";
        ProcInfo = "Main Processor   : AMD Athlon XP 2400+";
        MemTest = "Memory Testing   : ";
        DetectIDEvice = "Memory Frequrenzy is at <color=white>200</color> MHz, Dual Chanel mode<Br>";
        DetectedDevices = 
                     "  Primary Master  : SAMSUNG SV4084H PM100-21" +
            "<Br>" + "   Prymary Slave  : SAMSUNG SP4002H QU100-60" +
            "<Br>" + "Secondary Master  : Pioneer DVD-ROM ATAPIModel" +
            "<Br>" + " Secondary Slave  : SAMSUNG CF/ATA 04/05/06";
        //UperText.onCullStateChanged.AddListener(delegate { OnFontChange(); });
        FontSize = UperText.fontSize;
        OnRectTransformDimensionsChange();
    }
    private void OnRectTransformDimensionsChange()
    {
        float Iwidth = ResizeControlImage.rectTransform.rect.width;
        float Iheight = Iwidth / Sprite.rect.width * Sprite.rect.height;
        //Debug.Log(Iwidth + " " + Iheight);
        //UperTextRectTransform.rect.Set(UperTextRectTransform.rect.x, UperTextRectTransform.rect.y, UperTextRectTransform.rect.width, Iheight);
        UperTextRectTransform.sizeDelta = new Vector2(UperTextRectTransform.sizeDelta.x, Iheight);
        UperTextRectTransform.localPosition = new Vector3(UperTextRectTransform.localPosition.x, -Iheight, UperTextRectTransform.localPosition.z);
        //Debug.Log(UperTextRectTransform.rect + " " + Iheight);
        //Debug.Log(UperText.fontScale);
    }

    private void OnFontChange()
    {
        FontSize = UperText.fontSize;
        CenterText.fontSize = FontSize;
        DownerText.fontSize = FontSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(FontSize != UperText.fontSize)
        {
            OnFontChange();
        }
        //float LTMP = (LoadStatus - 15) * ((50 - 15) / 100);
        //Debug.Log(LTMP);
        //memTestStatus = (LoadStatus >= 15 && LoadStatus <= 50) ?(int)LTMP: (LoadStatus < 15) ? 0 : 100;
        string tmpText = ((LoadStatus <= 5) ? "" : Info) + "<Br><Br>" + ((LoadStatus >=10)?ProcInfo:"") + "<Br>" +
        ((memTestStatus > 0) ? MemTest + " " + memSize / 100 * memTestStatus + " " + ((memTestStatus >= 100) ? "OK" : "") : "") + "<Br><Br>" +
        ((IDEDetectStatus > 0) ? DetectIDEvice : "") + ((IDEDetectStatus > 10 && IDEDetectStatus < 80) ? "Detecting IDE device ..." : "") + ((IDEDetectStatus >= 80) ? DetectedDevices : "");

        CenterText.text = tmpText;
    }
}