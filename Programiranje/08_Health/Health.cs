using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText; //Prikaz healtha na UI
    public float currentHealth; // Trenutni health
    public float maxHealth = 100f; //Maximalni i pocetni health
    [Header("Regeneraciju upisite u iznosu regeneracije svake sekunde")]
    public float healthRegen; //Regeneracija healtha

    private void Start()
    {
        currentHealth = maxHealth;
        healthText.text = (int)currentHealth + "/" + (int)maxHealth;
    }

    private void Update()
    {
        //Regeneracija
        if(currentHealth < maxHealth && currentHealth > 0)
        {
            currentHealth += healthRegen * Time.deltaTime;
        }
        if(currentHealth <= 0)
        {
            //YOU DIED MADAFAKA
        }
        //DEBUG NAREDBA
        if(Input.GetKeyDown(KeyCode.U))
        {
            currentHealth -= 20;
        }
        healthText.text = (int)currentHealth + "/" + (int)maxHealth;
    }
}
