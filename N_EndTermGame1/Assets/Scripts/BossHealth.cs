using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float MaxHealth = 200f;
    public float CurrentHealth;

    public Slider BossHealthBar;
    public WakeUpBoss Bosswakeup;


    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        BossHealthBar.value = CurrentHealth;
    }
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Bosswakeup.Door1.SetActive(false);
            Bosswakeup.Door2.SetActive(false);
            Bosswakeup.BossHealthbar.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(5);
        }
    }


}
