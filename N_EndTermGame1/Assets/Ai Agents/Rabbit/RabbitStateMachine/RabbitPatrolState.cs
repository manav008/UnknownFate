using UnityEngine;
using UnityEngine.AI;

public class RabbitPatrolState : RabbitBaseState
{
    public float TimerBtwMove = 5;
    public float MoveinX = 10;
    public float MoveinZ = 10;

    public override void EnterState(RabbitStateManager Rabbit)
    {
        Rabbit.Agent.isStopped = false;
    }

    public override void UpdateState(RabbitStateManager Rabbit)
    {
        if(TimerBtwMove > 0)
        {
            TimerBtwMove -= Time.deltaTime;
        }
        else
        {
            TimerBtwMove = 5;
            float randX = Random.Range(MoveinX, -MoveinX) * 2;
            float randZ = Random.Range(MoveinZ, -MoveinZ) * 2;
            Vector3 randomDirection = new Vector3(Random.Range(Rabbit.transform.position.x, Rabbit.transform.position.x + randX), Rabbit.transform.position.y, Random.Range(Rabbit.transform.position.z, Rabbit.transform.position.z + randZ));
            Debug.Log("The random directuion to go is" + randomDirection);
            
            Rabbit.Agent.SetDestination(randomDirection);
        }

        if(Rabbit.CanSeePlayer)
        {
            Rabbit.SwitchState(Rabbit.RunState);
        }
    }

    public override void OnCollisionEnter(RabbitStateManager Rabbit, Collision collision)
    {

    }
}
