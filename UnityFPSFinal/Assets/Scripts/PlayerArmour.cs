using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerArmour : MonoBehaviour
{
    public static PlayerArmour singleton;
    public float fullArmour = 100f;
    public float currentArmour;
    public Slider armourSlider;
    public Text armourCounter;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        currentArmour = 50f;
        armourSlider.value = currentArmour;
        updateArmour();
        Debug.Log(currentArmour);
    }

    public void damageArmour(float damage)
    {
        float afterDamage = currentArmour - damage;

        if(afterDamage >= 0)
        {
            currentArmour -= damage;
            Debug.Log(currentArmour);
        }
        else
        {
            currentArmour = 0;
        }
        updateArmour();
    }

    public void addArmour(float armourAdded)
    {
        //need to add if statement
        float remainder = (currentArmour + armourAdded) - fullArmour;

        if (currentArmour < fullArmour)
        {
            currentArmour += armourAdded;

            if (remainder > 0)
            {
                currentArmour -= remainder;
            }
        }
        updateArmour();
        Debug.Log(currentArmour);
    }

    public float getArmour()
    {
        return currentArmour;
    }

    void updateArmour()
    {
        armourCounter.text = currentArmour.ToString() + " | 100";
        armourSlider.value = currentArmour;
    }
}
