using UnityEngine;
using UnityEngine.AI;

public class CowboyRunState : CowboyBaseState
{
    public float TimeBtwShots = 1;
    public override void EnterState(CowboyStateManager Cowboy)
    {
        Debug.Log("The enemy is now in Run State");
        Cowboy.agent.isStopped = false;
    }

    public override void UpdateState(CowboyStateManager Cowboy)
    {
        Cowboy.agent.SetDestination(Cowboy.Player.transform.position);
        float DistanceBtw = Vector3.Distance(Cowboy.transform.position, Cowboy.Player.transform.position);
        //Debug.Log("Distance from run is " + DistanceBtw);
        if(DistanceBtw <= 3)
        {
            Cowboy.agent.isStopped=true;
            Cowboy.SwitchState(Cowboy.AttackState);
        }
        else if(DistanceBtw >5 && Cowboy.CanSeePlayer == false)
        {
            Cowboy.SwitchState(Cowboy.PatrolState);
        }

        if (Cowboy.CowboyCurrentHealth <= 0)
        {
            Cowboy.SwitchState(Cowboy.DeathState);
        }

    }

    public override void OnCollisionEnter(CowboyStateManager Cowboy, Collision collision)
    {


    }
}
