using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Console : MonoBehaviour
{
    public TextMeshProUGUI ConsoleText;
    public TMP_InputField CoomandInput;

    CommandSystem CommandSystem;
    // Start is called before the first frame update
    void Start()
    {
        CommandSystem = new CommandSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
