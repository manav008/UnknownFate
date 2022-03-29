using UnityEngine;
using UnityEngine.AI;

public class CowbowIdleState : CowboyBaseState
{
    float Timerbtw = 5;
    public override void EnterState(CowboyStateManager Cowboy)
    {
        Debug.Log("Enemy Idle State");
        Cowboy.agent.isStopped = true;
        Cowboy.HandSword.SetActive(false);
        Cowboy.BackSword.SetActive(true);
    }

    public override void UpdateState(CowboyStateManager Cowboy)
    {
        if(Timerbtw > 0)
        {
            Timerbtw -= Time.deltaTime;
        }
        else
        {
            Timerbtw = 5;
            Cowboy.SwitchState(Cowboy.PatrolState);
        }

        if (Cowboy.CanSeePlayer)
        {
            Cowboy.SwitchState(Cowboy.RunState);
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
