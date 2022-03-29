using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class CharController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform cam;
    public float Speed = 6f;
    public GameObject Head;

    public float TurnSmoothTime = 0.1f;
    float TurnSmoothVelocity;

    public float PlayerHealth = 100;
    public float CurrentPlayerHealth;
    public float DamageAmount = 5;

    public CowboyStateManager CowbowManager;
    public Slider PlayerHealthBar;

    // For Sound System

    public AudioSource Audio_On_Player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        CurrentPlayerHealth = PlayerHealth;
        //PlayerHealthBar = GetComponent<Slider>();
        PlayerHealthBar.value = CurrentPlayerHealth;
        CurrentPlayerHealth = PlayerHealth;
        

    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 MoveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDirection.normalized * Speed * Time.deltaTime);
            
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Shoot");
            CowbowManager.TakeDamage(DamageAmount);
        }

        if(controller.isGrounded == true && controller.velocity.magnitude > 0f && Audio_On_Player.isPlaying == false)
        {
            Audio_On_Player.Play();
        }
        
        animator.SetFloat("VelocityX", horizontal);
        animator.SetFloat("VelocityY", vertical);

        


    }

    public void TakeDamage(float Damage)
    {
        CurrentPlayerHealth -= Damage;
        PlayerHealthBar.value = CurrentPlayerHealth;
    }

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "Bullet")
         {
             Debug.Log("I hit player");         
             CurrentPlayerHealth -= 5;

             Debug.Log("currernt player health is " + CurrentPlayerHealth);
             PlayerHealthBar.value = CurrentPlayerHealth;
         }
     }*/

    
}