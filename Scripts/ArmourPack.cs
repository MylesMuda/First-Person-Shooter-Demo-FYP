using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPack : MonoBehaviour
{
    [SerializeField]
    private float armourAmount = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerArmour>().addArmour(armourAmount);
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
