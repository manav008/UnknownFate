using UnityEngine;

public abstract class CowboyBaseState
{ 
    public abstract void EnterState(CowboyStateManager Cowboy);

    public abstract void UpdateState(CowboyStateManager Cowboy);

    public abstract void OnCollisionEnter(CowboyStateManager Cowboy, Collision collision);
}
    

