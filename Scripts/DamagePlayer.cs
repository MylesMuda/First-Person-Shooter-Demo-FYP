using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    //public bool canDamage = true;
    [SerializeField]
    private float healthDamage;

    [SerializeField]
    private float armourDamage;

    void Start()
    {
        healthDamage = 20f;
        armourDamage = 30f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().damageHealth(healthDamage);
            other.gameObject.GetComponent<PlayerArmour>().damageArmour(armourDamage);
            Debug.Log("Player hit");
        }
    }
}
