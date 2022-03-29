using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CowboyStateManager : MonoBehaviour
{
    public bool CanSeePlayer = false;
    public float EnemyRadius = 100.0f;

    CowboyBaseState CurrentState;
    public CowboyBaseState PatrolState = new CowboyPatrolState();
    public CowboyBaseState RunState = new CowboyRunState();
    public CowboyBaseState IdleState =  new CowbowIdleState();
    public CowboyBaseState AttackState = new CowboyAttackState();
    public CowboyBaseState DeathState = new CowboyDeathState();

    public Animator animator;
    public NavMeshAgent agent;

    private float q = 0.0f;
    public GameObject Player;

    public float CowboyHealth = 100;
    public float CowboyCurrentHealth;
    public Slider CowboyHealthbar;
    //public ProgressBarPro CowboyHealthbar;
    public GameObject Shootball;    // Start is called before the first frame update
    public Transform ShootPoint;

    public CharacterLocomotion PlayerController;

    public GameObject HandSword;
    public GameObject BackSword;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        CowboyCurrentHealth = CowboyHealth;
        //CowboyHealthbar = GetComponent<Slider>();
        //CowboyHealthbar.value = CowboyCurrentHealth;
        
        CurrentState = IdleState;
        CurrentState.EnterState(this);
    }

    public void OnCollisionEnter(Collision collision)
    {
        CurrentState.OnCollisionEnter(this, collision);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
        }

        if(collision.gameObject.CompareTag("Sword"))
        {
            TakeDamage(20);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = Player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos) * Quaternion.Inverse(Quaternion.Euler(0, 0, 0));
        CowboyHealthbar.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 5.0f * Time.deltaTime);


        CurrentState.UpdateState(this);
        animator.SetFloat("Move", agent.velocity.magnitude/2);
        Color color = new Color(q, q, 1.0f);
        Debug.DrawLine(transform.position, transform.position + new Vector3 (0,10,0), color);

        Collider[] HitColliders = Physics.OverlapSphere(transform.position, EnemyRadius);
        //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
        foreach (var hitCollider in HitColliders)
        {
            if (hitCollider.tag == "Player")
            {
                //Debug.Log("Hey i just hit the player and now i will chase him. Noice!");
                GameObject Player = hitCollider.gameObject;
                CanSeePlayer = true;
                Debug.Log("can see player");
                return;
            }
            else
            {
                CanSeePlayer = false;
            }
        }
        
    }

    public void AttackPlayer()
    {
        /*GameObject BulletInstance = Instantiate(Shootball, ShootPoint.transform.position, Quaternion.identity);
        BulletInstance.GetComponent<Rigidbody>().AddForce(BulletInstance.transform.forward * 25, ForceMode.Impulse);*/
       
        PlayerController.TakeDamage(5);
    }

    public void TakeDamage(float damage)
    {    
        CowboyCurrentHealth -= damage;
        
        CowboyHealthbar.value = CowboyCurrentHealth;
        //Debug.Log("Current Health is " + CowboyHealthbar.value);
    }

    

    public void SwitchState(CowboyBaseState State)
    {
        CurrentState = State;
        State.EnterState(this);
    }
}
