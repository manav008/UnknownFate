using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RoamAround : MonoBehaviour
{
    public Transform[] Points;
    public Animator anim;
    public NavMeshAgent agent;
    private int destPoint = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        GotoNextPoint();
    }

    private void Update()
    {
        anim.SetFloat("Move", agent.velocity.magnitude);
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (Points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = Points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % Points.Length;
    }




}
