using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WakeUpBoss : MonoBehaviour
{
    public GameObject BossHealthbar;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject BossTrigger;
    public BossHealth health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BossHealthbar.SetActive(true);
            Door1.SetActive(true);
            Door2.SetActive(true);
            BossTrigger.SetActive(false);
        }
    }

 
}
