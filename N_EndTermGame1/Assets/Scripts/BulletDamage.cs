using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    //public CharController PlayerController;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
