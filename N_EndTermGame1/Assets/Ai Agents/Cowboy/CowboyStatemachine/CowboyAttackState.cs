using UnityEngine;
using UnityEngine.AI;


public class CowboyAttackState : CowboyBaseState
{
    public float TimeBtwShots = 1;
    public override void EnterState(CowboyStateManager Cowboy)
    {
        Cowboy.agent.isStopped = true;
        Cowboy.HandSword.SetActive(true);
        Cowboy.BackSword.SetActive(false);
    }

    public override void UpdateState(CowboyStateManager Cowboy)
    {
        Vector3 relativePos = Cowboy.Player.transform.position - Cowboy.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 0, 0));
        Cowboy.transform.rotation = Quaternion.Lerp(Cowboy.transform.rotation, toRotation, 5.0f * Time.deltaTime);
        // Cowboy.transform.LookAt(Cowboy.Player.transform);
        if (TimeBtwShots > 0)
        {
            TimeBtwShots -= Time.deltaTime;
        }
        else
        {
            TimeBtwShots = 1;
            //Cowboy.animator.SetTrigger("Shoot");
            Cowboy.animator.SetTrigger("Attack");
            
                     
        }

        float DistanceBtw = Vector3.Distance(Cowboy.transform.position, Cowboy.Player.transform.position);
        if (DistanceBtw > 5 &&  Cowboy.CanSeePlayer == true)
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
