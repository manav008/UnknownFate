using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class RabbitAnimControl : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    //public bool shouldMove = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        agent.updatePosition = false;
    }

    void Update()
    {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);


        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        //anim.SetFloat("RabbitVel", velocity.y);
           // anim.SetBool("IsMoving", shouldMove);
            anim.SetFloat("VelocityX", velocity.x);
            anim.SetFloat("VelocityY", velocity.y);

        if(shouldMove == false)
        {
            //anim.SetBool("IsMoving", shouldMove);
            anim.SetFloat("VelocityX", 0);
            anim.SetFloat("VelocityY", 0);
        }

        //GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }

    void OnAnimatorMove()
    {

        transform.position = agent.nextPosition;
    }

}