using System.Collections;
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

    public int LoadStatus;
    public bool StartBios;
    public float FountSize;

    

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnRectTransformDimensionsChange()
    {
        float Iwidth = ResizeControlImage.rectTransform.rect.width;
        float Iheight = Iwidth / Sprite.rect.width * Sprite.rect.height;
        //Debug.Log(Iwidth + " " + Iheight);
        //UperTextRectTransform.rect.Set(UperTextRectTransform.rect.x, UperTextRectTransform.rect.y, UperTextRectTransform.rect.width, Iheight);
        //UperTextRectTransform.sizeDelta.Set(UperTextRectTransform.sizeDelta.x, Iheight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
