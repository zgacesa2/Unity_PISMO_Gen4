using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; //predmet koji se spawna
    public float timer; //vremenski period za spawnanje objekta
    float timerReset; //vraćanje timera na početak
    int spawnCount; //broj koliko smo prefaba stvorili

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float randomXpozicija = Random.Range(-7.0f, 7.0f);
            Debug.Log(randomXpozicija);
            Instantiate(prefab, new Vector3(randomXpozicija, 8, 0), Quaternion.identity);
            timer = timerReset;
            spawnCount++;
            //Svakih 13 stvorenih mi ubrzamo vrijeme stvaranja za 10%
            if(spawnCount == 13 && timerReset > 0.7f)
            {
                timerReset *= 0.9f;
                spawnCount = 0;
            }
        }
    }
}
