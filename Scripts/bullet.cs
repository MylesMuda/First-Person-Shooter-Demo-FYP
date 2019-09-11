using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 10f;

    [SerializeField]
    float projectileDamage = 30f;

    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealthScript = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.deductHealth(projectileDamage);
        }
    }
}
