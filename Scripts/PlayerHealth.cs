using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth singleton;
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;
    public Text healthCounter;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = maxHealth;
        updateHealth();
        Debug.Log(currentHealth);
    }

    public void damageHealth(float damage)
    {
        float afterDamage = currentHealth - damage;
        //need to add if statement
        if(afterDamage >= 0)
        {
            print("Player Dead!");
            currentHealth -= damage;
            Debug.Log(currentHealth);
        }
        else
        {
            currentHealth = 0;
        }
        updateHealth();
    }

    public void addHealth(float healthAdded)
    {
        //need to add if statement
        float totalHealth = currentHealth + healthAdded;
        float remainder = totalHealth - maxHealth;

        if(currentHealth < maxHealth)
        {
            currentHealth += healthAdded;

            if(remainder > 0)
            {
                currentHealth -= remainder;
            }
        }
        updateHealth();
        Debug.Log(currentHealth);
    }


    public float getHealth()
    {
        return currentHealth;
    }

    void updateHealth()
    {
        healthCounter.text = currentHealth.ToString() + " " + "| 100";
        healthSlider.value = currentHealth;
    }
}
