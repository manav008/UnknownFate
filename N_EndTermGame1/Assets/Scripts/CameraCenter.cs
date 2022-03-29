using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    public float rayLength = 100f;
    public GameObject ShootPoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 CenterHitPoint = GetHitPoint(ShootPoint.transform.position);
        Debug.Log("The center point is"+ CenterHitPoint);
    }

    public Vector3 GetHitPoint(Vector3 muzzlePosition)
    {
        // Unless you've mucked with the projection matrix, firing through
        // the center of the screen is the same as firing from the camera itself.
        Ray crosshair = new Ray(GetComponent<Camera>().transform.position, GetComponent<Camera>().transform.forward);

        // Cast a ray forward from the camera to see what's 
        // under the crosshair from the player's point of view.
        Vector3 aimPoint;
        RaycastHit hit;
        if (Physics.Raycast(crosshair, out hit, Mathf.Infinity))
        {
            aimPoint = hit.point;
        }
        else
        {
            aimPoint = crosshair.origin + crosshair.direction * rayLength;
        }

        // Now we know what to aim at, form a second ray from the tool.
        Ray beam = new Ray(muzzlePosition, aimPoint - muzzlePosition);

        // If we don't hit anything, just go straight to the aim point.
        if (!Physics.Raycast(beam, out hit, rayLength))
            return aimPoint;

        // Otherwise, stop at whatever we hit on the way.
        return hit.point;
    }
}
