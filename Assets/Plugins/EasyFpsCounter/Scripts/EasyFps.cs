//############################\\
//Copyrights (c) Lerp Games. \\
//Copyrights (c) varLG \\
//############################\\ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EasyFps : MonoBehaviour
{ 
    float refresht = 0.5f;
    int frameCounter = 0;
    float timeCounter = 0.0f;
    float lastFramerate = 0.0f;
    TMPro.TextMeshProUGUI txt; 

    void Start()
    {
        txt = GetComponentInChildren<TMPro.TextMeshProUGUI>(); 
    }

    void Update()
    {
        if (timeCounter < refresht)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;
        }
        else
        {
            lastFramerate = (float)frameCounter / timeCounter;
            int lastfrInt = (int)lastFramerate; 

            txt.text = "+" + lastfrInt; 

            frameCounter = 0;
            timeCounter = 0.0f; 
        }

    }


}
