using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FPSCounter : MonoBehaviour
{
    private Text textComponent;

    private List<float> fpsSamples = new List<float>();


    void Start()
    {
        textComponent = GetComponent<Text>();
    }


    void Update()
    {
        if (fpsSamples.Count > 60) 
        {
            fpsSamples.RemoveAt(0);
        }

        fpsSamples.Add((int)(1f / Time.unscaledDeltaTime));

        float averageFps = (int)fpsSamples.Average();

        textComponent.text = averageFps.ToString() + "FPS";
    }
}
