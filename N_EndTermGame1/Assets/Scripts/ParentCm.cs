using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCm : MonoBehaviour
{
    public float TimeToParent = 15;
    public GameObject Car;
    public Vector3 Offset;
    public ParentCm cm;

    // Update is called once per frame
    void Update()
    {
        if(TimeToParent > 0)
        {
            TimeToParent -= Time.deltaTime;
        }
        else
        {
            TimeToParent = 15;
            
            this.transform.parent = Car.transform;
            transform.localPosition = Offset;
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);            
            cm.enabled = false;
        }
    }
}
