using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterLocomotion : MonoBehaviour
{
    public Animator animator;
    public Vector2 input;
    public CharacterController controller;
    public float MoveSpeed = 10f;

    public Transform MainCamera;

    private Vector3 moveDirection = Vector3.zero;
    public LoadSceneAsnc NewLevel;

    //Health bar
    //public Slider PlayerHealthBar;
    public float PlayerHealth = 100;
    public float CurrentPlayerHealth;
    public float DamageAmount = 5;

    // For Sound System

    public AudioSource Source;
    public AudioClip FootStep;
    public bool CharGrounded;

    // Weapons

    public bool Normal = true;
    public bool SwordEquip = false;
    public bool MagicEquip = false;
    public GameObject Sword;


    // Particles-----------------------------

    public ParticleSystem ArcaneParticles;

    public ProgressBarPro PlayerHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        //Slider playerHealthBar = GetComponent<Slider>();
        CurrentPlayerHealth = PlayerHealth;
        //PlayerHealthBar.value = CurrentPlayerHealth;
        CurrentPlayerHealth = PlayerHealth;
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = MainCamera.TransformDirection(moveDirection);
        if (!controller.isGrounded)
        {
            moveDirection.y -= 10;
        }
        controller.Move(MoveSpeed * Time.deltaTime * moveDirection);

        // Equip Weapons ----------------------------
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sword.SetActive(false);
            SwordEquip = false;
            MagicEquip = false;
            animator.SetBool("Sword", false);
            animator.SetBool("Magic", false);
        }
        if (!MagicEquip)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Sword.SetActive(false);
                ArcaneParticles.Play();
                SwordEquip = false;
                MagicEquip = true;
                animator.SetBool("Sword", false);
                animator.SetBool("Magic", true);
            }
        }
        

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            MagicEquip=false;
            SwordEquip = true;
            Sword.SetActive(true);
            animator.SetBool("Magic", false);
            animator.SetBool("Sword", true);
        }

        // Attacks -----------------------------

        if(SwordEquip == true)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("SwordAttack1");
            }
        }

        animator.SetFloat("VelocityX", input.x);    
        animator.SetFloat("VelocityY", input.y);
    }

    public void FootStepSound()
    {
        Source.clip = FootStep;
        Source.Play();        
    }

    public void TakeDamage(float Damage)
    {
        CurrentPlayerHealth -= Damage;
        PlayerHealthbar.Value = CurrentPlayerHealth/PlayerHealth;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SleepArea"))
        {
            Debug.Log("In Sleep Area");
            NewLevel.LoadLevel(3);
           
        }
             
    }
}
