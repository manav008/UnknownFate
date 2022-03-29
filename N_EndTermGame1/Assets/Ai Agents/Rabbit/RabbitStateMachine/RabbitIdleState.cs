using UnityEngine;
using UnityEngine.AI;

public class RabbitIdleState : RabbitBaseState
{
    public float speed = 1;
    public float TimeForPatrol = 5;

    public override void EnterState(RabbitStateManager Rabbit)
    {
        //Rabbit.animator.SetBool("IsRunning", false);
        Debug.Log("Rabbit is in Idle State");
        Rabbit.Agent.isStopped = true;
    }

    public override void UpdateState(RabbitStateManager Rabbit)
    {
        /*float Distance = Vector3.Distance(Rabbit.Agent.transform.position, Rabbit.Player.transform.position);
        if (Distance < 2.5)
        {          
            Rabbit.SwitchState(Rabbit.RunState);
        }     */  

        if(TimeForPatrol > 0)
        {
            TimeForPatrol -= Time.deltaTime;
        }
        else
        {
            TimeForPatrol = 5;
            Rabbit.SwitchState(Rabbit.PatrolState);
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
