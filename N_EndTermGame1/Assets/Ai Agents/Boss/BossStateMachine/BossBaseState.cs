using UnityEngine;

public abstract class BossBaseState
{
    public abstract void EnterState(BossStateManager Boss);

    public abstract void UpdateState(BossStateManager Boss);

    public abstract void OnCollisionEnter(BossStateManager Boss, Collision collision);
}

