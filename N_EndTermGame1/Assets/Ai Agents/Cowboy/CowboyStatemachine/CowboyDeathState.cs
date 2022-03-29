using UnityEngine;
using UnityEngine.AI;

public class CowboyDeathState : CowboyBaseState
{
    public override void EnterState(CowboyStateManager Cowboy)
    {
        Debug.Log("Enemy is dead now");
        Cowboy.agent.isStopped = true;
        Cowboy.animator.SetTrigger("Death");
    }

    public override void UpdateState(CowboyStateManager Cowboy)
    {
     
    }

    public override void OnCollisionEnter(CowboyStateManager Cowboy, Collision collision)
    {

    }
}
