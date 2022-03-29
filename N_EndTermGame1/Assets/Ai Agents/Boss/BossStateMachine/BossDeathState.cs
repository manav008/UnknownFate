using UnityEngine;
using UnityEngine.AI;

public class BossDeathState : BossBaseState
{
    public override void EnterState(BossStateManager Boss)
    {
        Boss.Agent.isStopped = false;
    }

    public override void UpdateState(BossStateManager Boss)
    {
       
    }

    public override void OnCollisionEnter(BossStateManager Boss, Collision collision)
    {

    }
}
