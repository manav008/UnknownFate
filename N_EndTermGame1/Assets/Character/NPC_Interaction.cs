using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaction : MonoBehaviour
{

    //For SphereCast
    public float SphereRadius;
    public float MaxDistance;
    public LayerMask LayerMask;


    public Vector3 CastOrigin;
    private Vector3 Direction;

    public GameObject CurrentHitObject;
    public float CurrentHitDistance;

    public CharacterController controller;

    //Dialouge System

    //public GameObject OutGuard;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Casting a ray to deltect a npc in the players view

        CastOrigin = transform.position + controller.center/2;
        Direction = transform.forward;

        RaycastHit Hit;

        if (Physics.SphereCast(CastOrigin , SphereRadius, Direction, out Hit, MaxDistance, LayerMask, QueryTriggerInteraction.UseGlobal))
        {
            CurrentHitObject = Hit.transform.gameObject;
            //CurrentHitDistance = Hit.distance;
            if (CurrentHitObject.tag == "NPC")
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    CurrentHitObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    Debug.Log(CurrentHitObject.name);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                  FindObjectOfType<DialogueManager>().DisplayNextSentence();
                }
                Debug.Log(CurrentHitObject.tag);

            }
        }
        else
        {
            CurrentHitDistance = MaxDistance;
            CurrentHitObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(CastOrigin, CastOrigin + Direction * CurrentHitDistance);
        Gizmos.DrawWireSphere(CastOrigin + Direction * CurrentHitDistance, SphereRadius);
    }

}
