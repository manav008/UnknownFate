using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public float TurnSpeed = 15;
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float YawCamera = MainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, YawCamera, 0), TurnSpeed * Time.deltaTime);
    }
}
