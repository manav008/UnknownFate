using UnityEngine;
using UnityEngine.AI;

public class BossChaseState : BossBaseState
{
    //public float TimeToWait = 3;
    public override void EnterState(BossStateManager Boss)
    {   
        Boss.Agent.isStopped = false;
    }

    public override void UpdateState(BossStateManager Boss)
    {
        /*if(TimeToWait > 0)
        {
            TimeToWait -= Time.deltaTime;
        }
        else
        {
            TimeToWait = 3;
            
        }*/
        Boss.Agent.SetDestination(Boss.Player.transform.position);

        float DistanceBtw = Vector3.Distance(Boss.transform.position, Boss.Player.transform.position);
        Debug.Log(DistanceBtw);

        if(DistanceBtw < 30)
        {
            //Boss.Agent.isStopped = true;
            Boss.SwitchState(Boss.AttackState);
            
        }
    }

    public override void OnCollisionEnter(BossStateManager Boss, Collision collision)
    {

    }
}
