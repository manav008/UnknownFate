using UnityEngine;
using UnityEngine.AI;

public class RabbitRunState : RabbitBaseState
{
   
    public override void EnterState(RabbitStateManager Rabbit)
    {
        Rabbit.animator.SetBool("IsRunning", true);
        Debug.Log("Rabbit is in Run State");
        Rabbit.Agent.isStopped = false;
        
    }

    public override void UpdateState(RabbitStateManager Rabbit)
    {
        /*Rabbit.transform.LookAt(Rabbit.PlayerHead.transform);
        if(Rabbit.CanSeePlayer == false)
        {
            Rabbit.SwitchState(Rabbit.IdleState);
        }*/
        /*float Distance = Vector3.Distance(Rabbit.Agent.transform.position, Rabbit.Player.transform.position);
        if(Distance > 3)
        {
            Rabbit.SwitchState(Rabbit.IdleState);
        }*/
        
            Vector3 relativePos = Rabbit.Player.transform.position - Rabbit.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 60, 0));
            Rabbit.transform.rotation = Quaternion.Lerp(Rabbit.transform.rotation, toRotation, 5.0f * Time.deltaTime);

            Vector3 DirToPlayer = Rabbit.transform.position - Rabbit.Player.transform.position;
            Vector3 NewPos = Rabbit.transform.position + DirToPlayer;


            Rabbit.Agent.SetDestination(NewPos);

        

        if(!Rabbit.CanSeePlayer)
        {
            Rabbit.SwitchState(Rabbit.IdleState);
        }



        


    }

    public override void OnCollisionEnter(RabbitStateManager Rabbit, Collision collision)
    {
        
    }
}
