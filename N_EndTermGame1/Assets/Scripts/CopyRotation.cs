using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    // Update is called once per frame
    public GameObject Parent;
    void Update()
    {
        this.gameObject.transform.rotation = Parent.transform.rotation;
    }
}
