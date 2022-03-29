using UnityEngine;
using UnityEngine.AI;

public class BossAttackState : BossBaseState
{
    public int RandomNum = 0;
    public float TimeBtwAttacks = 4;

    public override void EnterState(BossStateManager Boss)
    {
        
        Debug.Log("Boss in attack State");
        Boss.Agent.isStopped = true;
    }

    public override void UpdateState(BossStateManager Boss)
    {
       // Boss.animator.SetFloat("VelocityX", 0);
        float DistanceBtw = Vector3.Distance(Boss.transform.position, Boss.Player.transform.position);
        if (DistanceBtw > 50)
        {
            Boss.SwitchState(Boss.ChaseState);
        }

        if (TimeBtwAttacks > 0)
        {
            TimeBtwAttacks -= Time.deltaTime;
        }
        else
        {
            TimeBtwAttacks = 4;
            RandomNum = Random.Range(1, 4);
            Boss.AttackPlayer(RandomNum);
        }
        //Debug.Log(RandomNum);      
        
        
    }



    public override void OnCollisionEnter(BossStateManager Boss, Collision collision)
    {

    }
}
