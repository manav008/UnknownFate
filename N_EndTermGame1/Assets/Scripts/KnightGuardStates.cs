using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class KnightGuardStates : MonoBehaviour
{
    public Transform[] Points;
    public Animator Anim;
    public NavMeshAgent Agent;
    public float TimerBtwMove = 5;
    public float TimertoPoint1 = 5;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        Agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(Points[0].transform.position);
        StartCoroutine("Moveto2", 2f);
        Anim.SetFloat("Move", Agent.velocity.magnitude);
        
    }
    
    private IEnumerator Moveto2()
    {
        yield return new WaitForSeconds(10);
        
        Agent.SetDestination(Points[1].transform.position);
    }
}
