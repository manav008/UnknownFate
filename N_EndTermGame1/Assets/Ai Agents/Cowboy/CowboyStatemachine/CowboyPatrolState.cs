using UnityEngine;
using UnityEngine.AI;

public class CowboyPatrolState : CowboyBaseState
{
    public float TimerBtwMove = 5f;
    public float MoveinX = 10;
    public float MoveinZ = 10;

    public override void EnterState(CowboyStateManager Cowboy)
    {
        Debug.Log("Enemy Patrol State");
        Cowboy.agent.isStopped = false;
        Cowboy.HandSword.SetActive(false);
        Cowboy.BackSword.SetActive(true);
    }

    public override void UpdateState(CowboyStateManager Cowboy)
    {
        if(TimerBtwMove > 0 )
        {
            TimerBtwMove -= Time.deltaTime;
        }
        else
        {
            float randX = Random.Range(MoveinX, -MoveinX) * 2;
            float randZ = Random.Range(MoveinZ, -MoveinZ) * 2;
            Vector3 randomDirection = new Vector3(Random.Range(Cowboy.transform.position.x, Cowboy.transform.position.x + randX), Cowboy.transform.position.y, Random.Range(Cowboy.transform.position.z, Cowboy.transform.position.z + randZ));
            Debug.Log("The random directuion to go is" + randomDirection);
            Cowboy.agent.SetDestination(randomDirection);
            TimerBtwMove = 5;
            Cowboy.SwitchState(Cowboy.IdleState);
            
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
