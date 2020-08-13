using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeCount = 11f; //Minute


    private void Start()
    {
        timeCount *= 60; //Pretvorili smo u sekunde
    }

    private void Update()
    {
        timeCount -= Time.deltaTime;
        if(timeCount >= 0)
        {
            //Djelimo sa cijelim brojem da dobijemo minute
            int minutes = (int)(timeCount / 60);
            //Djelimo sa 60 da dobijemo ostatak (% služi za djeljenej sa ostatkom) kako bismo dobili sekunde
            int seconds = Mathf.FloorToInt(timeCount % 60);
            //Ako je manje od 10 brojčano za minute i sekunde
            if(minutes < 10 && seconds < 10)
            {
                timerText.text = "0" + minutes + ":" + "0" + seconds;
            }
            //Minute su jednoznamenkaste, ali sekunde su dvoznamenkaste
            else if(minutes < 10 && seconds >= 10)
            {
                timerText.text = "0" + minutes + ":" + seconds;
            }
            //Minute se dvoznamenkaste, ali sekunde su jednoznamenkaste
            else if(minutes >= 10 && seconds < 10)
            {
                timerText.text = minutes + ": 0" + seconds;
            }
            //Minute i sekunde su nam dvoznamenkaste
            else
            {
                timerText.text = minutes + ":" + seconds;
            }
        }

    }
}
