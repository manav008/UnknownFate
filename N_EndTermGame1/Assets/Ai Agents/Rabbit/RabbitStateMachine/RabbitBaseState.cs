using UnityEngine;

public abstract class RabbitBaseState
{
    public abstract void EnterState(RabbitStateManager Rabbit);

    public abstract void UpdateState(RabbitStateManager Rabbit);

    public abstract void OnCollisionEnter(RabbitStateManager Rabbit, Collision collision);
}
