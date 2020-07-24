using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0; //broj bodova
    public int life = 3; //broj zivota
    public Text scoreText;
    public Text lifeText;

    private void Update()
    {
        //Mjenje texta scorea i lifea
        scoreText.text = "Score: " + score;
        lifeText.text = "Life: " + life;

        //Na tipku esc ugasi igru
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Izgubio si
        if(life <= 0)
        {
            Debug.Log("Izgubio si");
            Application.Quit();
        }
    }
}
