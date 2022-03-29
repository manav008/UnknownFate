using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitStateManager : MonoBehaviour
{
    RabbitBaseState CurrentState;
    public RabbitBaseState IdleState = new RabbitIdleState();
    public RabbitBaseState RunState = new RabbitRunState();
    public RabbitBaseState PatrolState = new RabbitPatrolState();

    public NavMeshAgent Agent;
    public GameObject Player;
    public Animator animator;
    public bool CanSeePlayer = false;
    public float EnemyRadius = 20.0f;
    

    public Transform PlayerHead;

  //  public Transform RabbitHole;

    void Start()
    {
        CurrentState = IdleState;
        CurrentState.EnterState(this);
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        CurrentState.OnCollisionEnter(this, collision);
    }

    void Update()
    {
        animator.SetFloat("Move", Agent.velocity.magnitude);
        CurrentState.UpdateState(this);
        //animator.SetFloat("RabbitVel", Agent.velocity.magnitude);


    Collider[] HitColliders = Physics.OverlapSphere(transform.position, EnemyRadius);
        //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
        foreach (var hitCollider in HitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
                GameObject Player = hitCollider.gameObject;
                CanSeePlayer = true;
                Debug.Log("can see player");
                return;
            }
            else
            {
                CanSeePlayer = false;
            }
        }
    }

    public void SwitchState(RabbitBaseState State)
    {
        CurrentState = State;
        State.EnterState(this);
    }

}
