using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public float fullHealth = 100f;
    public Slider healthSlider;
    public Text healthCounter;
    public Image hitmarker;

    void Start()
    {
        enemyHealth = fullHealth;
        healthSlider.value = fullHealth;
        updateHealth();
    }

    //public method needed as it is called by all weapon types
    public void deductHealth(float dHealth)
    {
        hitmarker.enabled = true;
        enemyHealth -= dHealth;
        if(enemyHealth <= 0) { targetDown(); }
        updateHealth();
        StartCoroutine(hitmarkerTimer());
    }

    private void targetDown()
    {
        //calls script given in Low Poly Asset Pack
        gameObject.GetComponent<TargetScript>().isHit = true;
        enemyHealth = fullHealth;
    }

    void updateHealth()
    {
        healthCounter.text = enemyHealth.ToString() + " " + "| 100";
        healthSlider.value = enemyHealth;
    }

    IEnumerator hitmarkerTimer()
    {
        yield return new WaitForSeconds(0.1f);
        hitmarker.enabled = false;
    }
}
