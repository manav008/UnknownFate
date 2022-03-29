using UnityEngine;
using UnityEngine.AI;

public class BossPatrolState : BossBaseState
{
    public float TimerBtwMove = 5f;
    public float MoveinX = 10;
    public float MoveinZ = 10;


    public override void EnterState(BossStateManager Boss)
    {
        Debug.Log("Boss patrol state");
        Boss.Agent.isStopped = false;
    }

    public override void UpdateState(BossStateManager Boss)
    {
        if (TimerBtwMove > 0)
        {
            TimerBtwMove -= Time.deltaTime;
        }
        else
        {
            float randX = Random.Range(MoveinX, -MoveinX) * 2;
            float randZ = Random.Range(MoveinZ, -MoveinZ) * 2;
            Vector3 randomDirection = new Vector3(Random.Range(Boss.transform.position.x, Boss.transform.position.x + randX), Boss.transform.position.y, Random.Range(Boss.transform.position.z, Boss.transform.position.z + randZ));
            Debug.Log("The random directuion to go is" + randomDirection);
            Boss.Agent.SetDestination(randomDirection);
            TimerBtwMove = 5;
            Boss.SwitchState(Boss.IdleState);
        }

        /*if (Boss.CanSeePlayer)
        {
            Boss.SwitchState(Boss.RunState);
        }


        if (Boss.CowboyCurrentHealth <= 0)
        {
            Boss.SwitchState(Boss.DeathState);
        }*/
    }

    public override void OnCollisionEnter(BossStateManager Boss, Collision collision)
    {

    }
}
