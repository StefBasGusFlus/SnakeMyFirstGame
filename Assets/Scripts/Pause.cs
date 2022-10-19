using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text text;
    private float timeNow;

    public void ButtonPause()
    {
        if (Time.timeScale != 0)
        {
            timeNow = Time.timeScale;
            Time.timeScale = 0;
            text.color = new Color(0,0,0,1);
        }
        else
        {
            Time.timeScale = timeNow;
            text.color = new Color(0,0,0,0.569f);
        }
    }
}
