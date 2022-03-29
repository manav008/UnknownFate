using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossStateManager : MonoBehaviour
{
    
    BossBaseState CurrentState;
    public BossBaseState IdleState = new BossIdleState();
    public BossBaseState PatrolState = new BossPatrolState();
    public BossBaseState AttackState = new BossAttackState();
    public BossBaseState ChaseState = new BossChaseState();
    public BossBaseState DeathState = new BossDeathState();

    public NavMeshAgent Agent;
    public Animator animator;

    public bool CanSeePlayer = false;
    public float EnemyRadius = 50f;

    public GameObject Player;

    public BossHealth BHealth;

    public CharacterLocomotion PlayerController;
    

    void Start()
    {
        CurrentState = IdleState;        
        CurrentState.EnterState(this);
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        CurrentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {

        CurrentState.UpdateState(this);

        animator.SetFloat("VelocityX", Agent.velocity.magnitude);
        /*Vector3 relativePos = Player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 0, 0));
        CowboyHealthbar.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 5.0f * Time.deltaTime);*/


        Collider[] HitColliders = Physics.OverlapSphere(transform.position, EnemyRadius);
        //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
        foreach (var hitCollider in HitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
                //GameObject Player = hitCollider.gameObject;
                CanSeePlayer = true;
                Debug.Log("can see player");
                return;
            }
            else
            {
                CanSeePlayer = false;
            }
        }

        if(BHealth.CurrentHealth <= 0)
        {
            CurrentState = DeathState;
        }
    }

    public void SwitchState(BossBaseState State)
    {
        CurrentState = State;
        State.EnterState(this);
    }

    public void AttackPlayer(int AttackMove)
    {
        if(AttackMove == 1)
        {
            animator.SetTrigger("Attack1");
        }
        else if(AttackMove == 2)
        {
            animator.SetTrigger("Attack2");
        }
        else if(AttackMove == 3)
        {
            animator.SetTrigger("Attack3");
        }
    }

    public void Attack1Damage()
    {
        PlayerController.TakeDamage(10);
    }

    public void Attack2Damage()
    {
        PlayerController.TakeDamage(20);
    }

    public void Attack3Damage()
    {
        PlayerController.TakeDamage(15);
    }
}