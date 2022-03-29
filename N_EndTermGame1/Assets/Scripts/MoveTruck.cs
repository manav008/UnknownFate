using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTruck : MonoBehaviour
{
    public Transform PointToMove;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.localPosition, PointToMove.localPosition, Time.deltaTime * step);
    }
}
