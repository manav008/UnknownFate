using UnityEngine;
using UnityEngine.AI;

public class BossIdleState : BossBaseState
{
    //float Timerbtw = 5;
    public override void EnterState(BossStateManager Boss)
    {
        //Boss.Agent.isStopped = true;
        Debug.Log("Enemy Idle State");
        Boss.Agent.isStopped = true;
        
    }

    public override void UpdateState(BossStateManager Boss)
    {
        /*if (Timerbtw > 0)
        {
            Timerbtw -= Time.deltaTime;
        }
        else
        {
            Timerbtw = 5;
            Boss.SwitchState(Boss.PatrolState);
        }*/

        if(Boss.CanSeePlayer == true)
        {
            Boss.animator.SetTrigger("Taunt");
            Boss.SwitchState(Boss.ChaseState);
        }

        
    }

    public override void OnCollisionEnter(BossStateManager Boss, Collision collision)
    {

    }
}
