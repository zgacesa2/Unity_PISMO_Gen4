using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public float timer = 5.13f;
    float timerReset;

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            int randomEnemy = Random.Range(0, enemies.Length); // sprema jedan broj od 0 do 2
            int randomSpawn = Random.Range(0, spawnPoints.Length); //sprema jedan broj od 0 do 5
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
            Debug.Log("Stvoren je: " + enemies[randomEnemy].name + " na poziciji: " + spawnPoints[randomSpawn].name);
            timer = timerReset;
        }
    }
}
