
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace MagicArsenal
{
public class MagicFireProjectile : MonoBehaviour 
{
    RaycastHit hit;
    public GameObject[] projectiles;
    public Transform spawnPosition;
    [HideInInspector]
    public int currentProjectile = 0;
	public float speed = 1000;
    public GameObject CrossHair;

     public LayerMask Mask;
     public CharacterLocomotion CharLoco;
    
   

        //    MyGUI _GUI;
      MagicButtonScript selectedProjectileButton;
        

	void Start () 
	{
		//selectedProjectileButton = GameObject.Find("Button").GetComponent<MagicButtonScript>();
	}

	void Update () 
	{
            if(CharLoco.MagicEquip == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hit, Mathf.Infinity, Mask))
                    {
                        
                        //Vector3 colisionPoint = hit.point;
                        //Vector3 bulletVector = colisionPoint - spawnPosition.transform.position;

                        GameObject projectile = Instantiate(projectiles[currentProjectile], spawnPosition.position, Quaternion.identity) as GameObject;
                        projectile.transform.LookAt(hit.point);
                        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                        // projectile.GetComponent<MagicProjectileScript>().impactNormal = hit.normal;
                    }
                }

                Debug.DrawRay(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.yellow);
            }
            
	}

    /*public void nextEffect()
    {
        if (currentProjectile < projectiles.Length - 1)
            currentProjectile++;
        else
            currentProjectile = 0;
		selectedProjectileButton.getProjectileNames();
    }

    public void previousEffect()
    {
        if (currentProjectile > 0)
            currentProjectile--;
        else
            currentProjectile = projectiles.Length-1;
		selectedProjectileButton.getProjectileNames();
    }*/

	public void AdjustSpeed(float newSpeed)
	{
		speed = newSpeed;
	}
    
    }
}