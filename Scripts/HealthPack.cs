using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private float healthAmount = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().addHealth(healthAmount);
            //gameObject.SetActive(false);
            StartCoroutine(itemResetTimer());
            //gameObject.SetActive(true);
        }
    }

    IEnumerator itemResetTimer()
    {
        yield return new WaitForSeconds(3f);
    }
}
